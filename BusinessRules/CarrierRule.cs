using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class CarrierRule
    {
        /// <summary>
        /// 新增承运单位档案
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listCar"></param>
        /// <param name="listDriver"></param>
        /// <param name="listExpression"></param>
        /// <param name="listTransportPrice"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertCarrier(Carrier data, List<CarrierCar> listCar, List<CarrierDriver> listDriver, List<CarrierSettlementExpression> listExpression, List<CarrierTransportPrice> listTransportPrice, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nCarrierId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        //新增承运单位档案数据
                        nCarrierId = dao.InsertCarrier(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nCarrierId <= 0)
                            return 0;

                        //新增车辆数据
                        foreach (CarrierCar car in listCar)
                        {
                            car.CarrierId = nCarrierId;
                            if (!dao.InsertCarrierCar(car, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }

                        //新增驾驶员数据
                        foreach (CarrierDriver driver in listDriver)
                        {
                            driver.CarrierId = nCarrierId;
                            if (!dao.InsertCarrierDriver(driver, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }

                        //新增结算公式数据
                        foreach (CarrierSettlementExpression expression in listExpression)
                        {
                            expression.CarrierId = nCarrierId;
                            if (!dao.InsertCarrierSettlementExpression(expression, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }

                        //新增承运价格数据
                        foreach (CarrierTransportPrice price in listTransportPrice)
                        {
                            price.CarrierId = nCarrierId;
                            if (!dao.InsertCarrierTransportPrice(price, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nCarrierId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
        }

        /// <summary>
        /// 修改承运单位档案
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listCar"></param>
        /// <param name="listDriver"></param>
        /// <param name="listExpression"></param>
        /// <param name="listTransportPrice"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateCarrier(Carrier data, List<CarrierCar> listCar, List<CarrierDriver> listDriver, List<CarrierSettlementExpression> listExpression, List<CarrierTransportPrice> listTransportPrice, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        //修改承运单位档案数据
                        if (!dao.UpdateCarrier(data, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //修改车辆数据
                        List<CarrierCar> listOldCar = dao.LoadCarrierCars(data.Id, nOpStaffId, strOpStaffName, out strErrText);
                        if (listOldCar == null)
                        {
                            return false;
                        }
                        foreach (CarrierCar oldCar in listOldCar)
                        {
                            if (!listCar.Exists(delegate(CarrierCar newCar) { return oldCar.Id == newCar.Id; }))
                            {
                                //删除车辆数据
                                if (!dao.DeleteCarrierCar(oldCar.Id, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                        }
                        foreach (CarrierCar newCar in listCar)
                        {
                            if (newCar.Id > 0)
                            {
                                //修改车辆数据
                                if (!dao.UpdateCarrierCar(newCar, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                        }
                        foreach (CarrierCar newCar in listCar)
                        {
                            if (newCar.Id == 0)
                            {
                                //新增车辆数据
                                if (!dao.InsertCarrierCar(newCar, nOpStaffId, strOpStaffName, out strErrText))
                                {
                                    return false;
                                }
                            }
                        }

                        //修改驾驶员数据
                        if (!dao.DeleteCarrierDrivers(data.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                        foreach (CarrierDriver driver in listDriver)
                        {
                            if (!dao.InsertCarrierDriver(driver, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }

                        //修改结算公式数据
                        if (!dao.DeleteCarrierSettlementExpressions(data.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                        foreach (CarrierSettlementExpression expression in listExpression)
                        {
                            if (!dao.InsertCarrierSettlementExpression(expression, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }

                        //修改承运价格数据
                        if (!dao.DeleteCarrierTransportPrices(data.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                        foreach (CarrierTransportPrice price in listTransportPrice)
                        {
                            if (!dao.InsertCarrierTransportPrice(price, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return false;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return true;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 删除承运单位档案
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCarrier(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        //删除承运单位档案数据
                        if (!dao.DeleteCarrier(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除车辆数据
                        if (!dao.DeleteCarrierCars(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除驾驶员数据
                        if (!dao.DeleteCarrierDrivers(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }

                        //删除运费价格数据
                        if (!dao.DeleteCarrierTransportPrices(nId, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                    }
                    transScope.Complete();
                }
                return true;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return false;
            }
        }

    }
}

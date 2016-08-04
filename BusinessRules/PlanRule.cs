using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class PlanRule
    {
        /// <summary>
        /// 新增发货计划
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertDeliverPlan(DeliverPlan data, List<DeliverPlanGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nPlanId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        //新增计划数据
                        nPlanId = dao.InsertDeliverPlan(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nPlanId <= 0)
                            return 0;

                        //新增货物数据
                        foreach (DeliverPlanGoods goods in listGoods)
                        {
                            goods.PlanId = nPlanId;

                            if (!dao.InsertDeliverPlanGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nPlanId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
        }

        /// <summary>
        /// 修改发货计划
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listGoods"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDeliverPlan(DeliverPlan data, List<DeliverPlanGoods> listGoods, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        //修改计划数据
                        if (!dao.UpdateDeliverPlan(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        //修改货物数据
                        if (!dao.DeleteDeliverPlanAllGoods(data.Id, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                        foreach (DeliverPlanGoods goods in listGoods)
                        {
                            goods.PlanId = data.Id;
                            if (!dao.InsertDeliverPlanGoods(goods, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 修改发货计划备注
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="strRemark"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateDeliverPlanRemark(long nId, string strRemark, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (PlanDAO dao = new PlanDAO())
                    {
                        //读取计划数据
                        DeliverPlan data = dao.LoadDeliverPlan(nId, nOpStaffId, strOpStaffName, out  strErrText);
                        if (data == null)
                        {
                            return false;
                        }

                        //修改计划数据
                        data.Remark = strRemark;
                        if (!dao.UpdateDeliverPlan(data, nOpStaffId, strOpStaffName, out strErrText))
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

using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Rules
{
    public class ReceiverRule
    {
        /// <summary>
        /// 新增收货单位数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listDistance"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertReceiver(Receiver data, List<ReceiverDistance> listDistance, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            long nReceiverId = 0;

            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        //新增收货单位数据
                        nReceiverId = dao.InsertReceiver(data, nOpStaffId, strOpStaffName, out strErrText);
                        if (nReceiverId <= 0)
                            return 0;

                        //新增距离数据
                        foreach (ReceiverDistance distance in listDistance)
                        {
                            if (!dao.InsertReceiverDistance(distance, nOpStaffId, strOpStaffName, out strErrText))
                            {
                                return 0;
                            }
                        }
                    }
                    transScope.Complete();
                }
                return nReceiverId;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return 0;
            }
        }

        /// <summary>
        /// 修改收货单位数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listDistance"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateReceiver(Receiver data, List<ReceiverDistance> listDistance, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        //修改收货单位档案数据
                        if (!dao.UpdateReceiver(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        //修改距离数据
                        if (!dao.DeleteReceiverDistances(data.Name, nOpStaffId, strOpStaffName, out strErrText))
                        {
                            return false;
                        }
                        foreach (ReceiverDistance distance in listDistance)
                        {
                            if (!dao.InsertReceiverDistance(distance, nOpStaffId, strOpStaffName, out strErrText))
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
        /// 删除收货单位数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteReceiver(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        //读取收货单位档案数据
                        Receiver data = dao.LoadReceiver(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (data == null)
                            return false;

                        //删除收货单位档案数据
                        if (!dao.DeleteReceiver(nId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;

                        //删除距离数据
                        if (!dao.DeleteReceiverDistances(data.Name, nOpStaffId, strOpStaffName, out strErrText))
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

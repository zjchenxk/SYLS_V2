using System;
using System.Collections.Generic;
using System.Transactions;
using InnoSoft.LS.Business.Rules;
using InnoSoft.LS.Data.Access;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Business.Facades
{
    public class DDSystem : MarshalByRefObject
    {
        #region 国家自定义代码

        /// <summary>
        /// 读取所有国家自定义数据
        /// </summary>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>国家数据集</returns>
        public List<Country> LoadCountrys(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Country> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCountrys(nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定国家自定义数据
        /// </summary>
        /// <param name="nCountryId">国家编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>国家数据集</returns>
        public Country LoadCountry(long nCountryId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Country dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadCountry(nCountryId, nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增国家自定义数据
        /// </summary>
        /// <param name="data">国家自定义数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool InsertCountry(Country data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.InsertCountry(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 修改国家自定义数据
        /// </summary>
        /// <param name="data">国家自定义数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool UpdateCountry(Country data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.UpdateCountry(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 删除国家自定义数据
        /// </summary>
        /// <param name="nCountryId">国家编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool DeleteCountry(long nCountryId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.DeleteCountry(nCountryId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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

        #endregion

        #region 省份自定义代码

        /// <summary>
        /// 读取指定国家省份自定义数据
        /// </summary>
        /// <param name="strCountryName">国家名称</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<Province> LoadProvincesByCountry(string strCountryName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Province> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadProvincesByCountry(strCountryName, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取所有省份自定义数据
        /// </summary>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>省份数据集</returns>
        public List<Province> LoadProvinces(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Province> dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadProvinces(nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定省份自定义数据
        /// </summary>
        /// <param name="nProvinceId">省份编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>省份数据集</returns>
        public Province LoadProvince(long nProvinceId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Province dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadProvince(nProvinceId, nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增省份自定义数据
        /// </summary>
        /// <param name="data">省份自定义数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool InsertProvince(Province data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.InsertProvince(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 修改省份自定义数据
        /// </summary>
        /// <param name="data">省份自定义数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool UpdateProvince(Province data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.UpdateProvince(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 删除省份自定义数据
        /// </summary>
        /// <param name="nProvinceId">省份编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool DeleteProvince(long nProvinceId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO daoDD = new DDDAO())
                    {
                        if (!daoDD.DeleteProvince(nProvinceId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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

        #endregion

        #region 城市自定义代码

        /// <summary>
        /// 读取所有城市自定义数据
        /// </summary>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>城市数据集</returns>
        public List<City> LoadCitys(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<City> dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadCitys(nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定国家的城市数据集
        /// </summary>
        /// <param name="strCountryName">国家名称</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<City> LoadCitysByCountry(string strCountryName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<City> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCitysByCountry(strCountryName, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定省份的城市数据集
        /// </summary>
        /// <param name="strCountryName">国家名称</param>
        /// <param name="strProvinceName">省份名称</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<City> LoadCitysByProvince(string strCountryName, string strProvinceName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<City> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCitysByProvince(strCountryName, strProvinceName, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定城市自定义数据
        /// </summary>
        /// <param name="nCityId">城市编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>城市数据集</returns>
        public City LoadCity(long nCityId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                City dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadCity(nCityId, nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增城市自定义数据
        /// </summary>
        /// <param name="data">城市自定义数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool InsertCity(City data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.InsertCity(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 修改城市自定义数据
        /// </summary>
        /// <param name="data">城市自定义数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool UpdateCity(City data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.UpdateCity(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 删除城市自定义数据
        /// </summary>
        /// <param name="nCityId">城市编码数组</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回True，否则返回False</returns>
        public bool DeleteCity(long nCityId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.DeleteCity(nCityId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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

        #endregion

        #region 货物类别自定义代码

        /// <summary>
        /// 读取所有货物类别
        /// </summary>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<GoodsType> LoadGoodsTypes(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<GoodsType> dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadGoodsTypes(nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定货物类别和所有子类别
        /// </summary>
        /// <param name="nTypeId">类别编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<GoodsType> LoadSubGoodsTypes(long nTypeId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<GoodsType> dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadSubGoodsTypes(nTypeId, nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定货物类别
        /// </summary>
        /// <param name="nTypeId">类别编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public GoodsType LoadGoodsType(long nTypeId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                GoodsType dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadGoodsType(nTypeId, nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增货物类别
        /// </summary>
        /// <param name="data">货物类别数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool InsertGoodsType(GoodsType data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.InsertGoodsType(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 修改货物类别
        /// </summary>
        /// <param name="data">货物类别数据集</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool UpdateGoodsType(GoodsType data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.UpdateGoodsType(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 删除货物类别
        /// </summary>
        /// <param name="nTypeId">货物类别编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public bool DeleteGoodsType(long nTypeId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.DeleteGoodsType(nTypeId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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

        #endregion

        #region 货物自定义代码

        /// <summary>
        /// 读取所有货物
        /// </summary>
        /// <param name="strTypeId"></param>
        /// <param name="strGoodsNo"></param>
        /// <param name="strGoodsName"></param>
        /// <param name="strSpecModel"></param>
        /// <param name="strGWeight"></param>
        /// <param name="strGrade"></param>
        /// <param name="strPacking"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<Goods> LoadAllGoodsByConditions(string strTypeId, string strGoodsNo, string strGoodsName, string strSpecModel, string strGWeight, string strGrade, string strPacking, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Goods> dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadAllGoodsByConditions(strTypeId, strGoodsNo, strGoodsName, strSpecModel, strGWeight, strGrade, strPacking, nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据货物编号读取所有货物编号数据
        /// </summary>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public List<Goods> LoadAllGoodsByGoodsNo(string strGoodsNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Goods> dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadAllGoodsByGoodsNo(strGoodsNo, nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定的货物数据
        /// </summary>
        /// <param name="nId">货物编码</param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns></returns>
        public Goods LoadGoods(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Goods dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadGoods(nId, nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据货物编号读取指定货物数据
        /// </summary>
        /// <param name="strGoodsNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Goods LoadGoodsByGoodsNo(string strGoodsNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Goods dsRet = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dsRet = dao.LoadGoodsByGoodsNo(strGoodsNo, nOpStaffId, strOpStaffName, out strErrText);
                        if (dsRet == null)
                            return null;
                    }
                    transScope.Complete();
                }
                return dsRet;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增货物自定义数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool InsertGoods(Goods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.InsertGoods(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 修改货物自定义数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool UpdateGoods(Goods data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.UpdateGoods(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 删除指定的货物档案
        /// </summary>
        /// <param name="nId">货物编码</param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteGoods(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.DeleteGoods(nId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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

        #endregion

        #region 仓库自定义代码

        /// <summary>
        /// 读取所有仓库数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Warehouse> LoadWarehouses(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Warehouse> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadWarehouses(nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定仓库数据
        /// </summary>
        /// <param name="nId">仓库编码</param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Warehouse LoadWarehouse(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Warehouse dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadWarehouse(nId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增仓库数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertWarehouse(Warehouse data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.InsertWarehouse(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 修改仓库数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateWarehouse(Warehouse data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.UpdateWarehouse(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 修改仓库数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteWarehouse(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.DeleteWarehouse(nId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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

        #endregion

        #region 承运单位自定义代码

        /// <summary>
        /// 读取所有承运单位数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Carrier> LoadCarriers(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Carrier> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarriers(nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定承运单位档案数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Carrier LoadCarrier(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Carrier dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarrier(nId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定承运单位的车辆数据
        /// </summary>
        /// <param name="nCarrierId">承运单位编码</param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierCar> LoadCarrierCars(long nCarrierId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierCar> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarrierCars(nCarrierId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定承运单位的驾驶员数据
        /// </summary>
        /// <param name="nCarrierId">承运单位编码</param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierDriver> LoadCarrierDrivers(long nCarrierId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierDriver> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarrierDrivers(nCarrierId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定承运单位的结算公式数据
        /// </summary>
        /// <param name="nCarrierId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierSettlementExpression> LoadCarrierSettlementExpressions(long nCarrierId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierSettlementExpression> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarrierSettlementExpressions(nCarrierId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取承运单位指定结算公式数据
        /// </summary>
        /// <param name="nCarrierId"></param>
        /// <param name="strPlanType"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public CarrierSettlementExpression LoadCarrierSettlementExpression(long nCarrierId, string strPlanType, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                CarrierSettlementExpression dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarrierSettlementExpression(nCarrierId, strPlanType, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定承运单位的运费价格数据
        /// </summary>
        /// <param name="nCarrierId">承运单位编码</param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierTransportPrice> LoadCarrierTransportPrices(long nCarrierId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierTransportPrice> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarrierTransportPrices(nCarrierId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定承运单位、起点和讫点的运输价格数据
        /// </summary>
        /// <param name="nCarrierId"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="strPlanType"></param>
        /// <param name="dtCreateTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public CarrierTransportPrice LoadCarrierTransportPrice(long nCarrierId, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, string strPlanType, DateTime dtCreateTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                CarrierTransportPrice dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarrierTransportPrice(nCarrierId, strStartCountry, strStartProvince, strStartCity, strDestCountry, strDestProvince, strDestCity, strPlanType, dtCreateTime, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

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
            CarrierRule rule = new CarrierRule();
            return rule.InsertCarrier(data, listCar, listDriver, listExpression, listTransportPrice, nOpStaffId, strOpStaffName, out strErrText);
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
            CarrierRule rule = new CarrierRule();
            return rule.UpdateCarrier(data, listCar, listDriver, listExpression, listTransportPrice, nOpStaffId, strOpStaffName, out strErrText);
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
            CarrierRule rule = new CarrierRule();
            return rule.DeleteCarrier(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 读取所有承运单位的车辆数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierCar> LoadCars(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierCar> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCars(nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取包含指定车号的车辆数据
        /// </summary>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierCar> LoadCarsByCarNo(string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierCar> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarsByCarNo(strCarNo, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据车号读取指定承运单位数据
        /// </summary>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Carrier LoadCarrierByCarNo(string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Carrier dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarrierByCarNo(strCarNo, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据车号读取指定车辆数据
        /// </summary>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public CarrierCar LoadCarByCarNo(string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                CarrierCar dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarByCarNo(strCarNo, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定车号的驾驶员记录
        /// </summary>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierDriver> LoadDriversByCarNo(string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierDriver> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadDriversByCarNo(strCarNo, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定驾驶员数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public CarrierDriver LoadDriver(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                CarrierDriver dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadDriver(nId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定承运单位的车辆数据
        /// </summary>
        /// <param name="strCarrierName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<CarrierCar> LoadCarrierCars(string strCarrierName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<CarrierCar> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarrierCars(strCarrierName, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定时间段内发生业务的承运单位数据
        /// </summary>
        /// <param name="strStartTime"></param>
        /// <param name="strEndTime"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Carrier> LoadGenerateBusinessCarriersByTimespan(string strStartTime, string strEndTime, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Carrier> dataResult = null;
                strErrText = String.Empty;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadGenerateBusinessCarriersByTimespan(strStartTime, strEndTime, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定名称的承运单位数据
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Carrier LoadCarrierByName(string strName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Carrier dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarrierByName(strName, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据综合条件读取承运单位数据
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strCarNo"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Carrier> LoadCarriersByConditions(string strName, string strCarNo, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Carrier> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCarriersByConditions(strName, strCarNo, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        #endregion

        #region 运费限价自定义代码

        /// <summary>
        /// 读取所有运费限价数据
        /// </summary>
        /// <param name="strPlanType"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="strDestCountry"></param>
        /// <param name="strDestProvince"></param>
        /// <param name="strDestCity"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<TransportLimitedPrice> LoadTransportLimitedPricesByConditions(string strPlanType, string strStartCountry, string strStartProvince, string strStartCity, string strDestCountry, string strDestProvince, string strDestCity, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<TransportLimitedPrice> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadTransportLimitedPricesByConditions(strPlanType, strStartCountry, strStartProvince, strStartCity, strDestCountry, strDestProvince, strDestCity, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定运费限价数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public TransportLimitedPrice LoadTransportLimitedPrice(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                TransportLimitedPrice dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadTransportLimitedPrice(nId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 新增运费限价记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertTransportLimitedPrice(TransportLimitedPrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.InsertTransportLimitedPrice(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 修改运费限价记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateTransportLimitedPrice(TransportLimitedPrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.UpdateTransportLimitedPrice(data, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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
        /// 删除运费限价记录
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteTransportLimitedPrice(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        if (!dao.DeleteTransportLimitedPrice(nId, nOpStaffId, strOpStaffName, out strErrText))
                            return false;
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

        #endregion

        #region 提货单位自定义代码

        /// <summary>
        /// 读取所有提货单位数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Receiver> LoadReceivers(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Receiver> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadReceivers(nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据名称读取所有提货单位名称数据
        /// </summary>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Receiver> LoadReceiverNamesByName(string strName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Receiver> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadReceiverNamesByName(strName, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据名称读取提货单位数据
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Receiver LoadReceiverByName(string strName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Receiver dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadReceiverByName(strName, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 根据客户名称读取提货单位数据
        /// </summary>
        /// <param name="strCustomerName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<Receiver> LoadCustomerReceivers(string strCustomerName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<Receiver> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadCustomerReceivers(strCustomerName, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

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
            ReceiverRule rule = new ReceiverRule();
            return rule.InsertReceiver(data, listDistance, nOpStaffId, strOpStaffName, out strErrText);
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
            ReceiverRule rule = new ReceiverRule();
            return rule.UpdateReceiver(data, listDistance, nOpStaffId, strOpStaffName, out strErrText);
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
            ReceiverRule rule = new ReceiverRule();
            return rule.DeleteReceiver(nId, nOpStaffId, strOpStaffName, out strErrText);
        }

        /// <summary>
        /// 读取指定起点到指定收货单位的距离
        /// </summary>
        /// <param name="strReceiverName"></param>
        /// <param name="strStartCountry"></param>
        /// <param name="strStartProvince"></param>
        /// <param name="strStartCity"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public ReceiverDistance LoadReceiverDistance(string strReceiverName, string strStartCountry, string strStartProvince, string strStartCity, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                ReceiverDistance dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadReceiverDistance(strReceiverName, strStartCountry, strStartProvince, strStartCity, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定收货单位的所有距离数据
        /// </summary>
        /// <param name="nReceiverId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public List<ReceiverDistance> LoadReceiverDistances(long nReceiverId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                List<ReceiverDistance> dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadReceiverDistances(nReceiverId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        /// <summary>
        /// 读取指定收货单位数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public Receiver LoadReceiver(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            try
            {
                Receiver dataResult = null;

                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(2, 0, 0)))
                {
                    using (DDDAO dao = new DDDAO())
                    {
                        dataResult = dao.LoadReceiver(nId, nOpStaffId, strOpStaffName, out strErrText);
                    }
                    transScope.Complete();
                }
                return dataResult;
            }
            catch (Exception e)
            {
                strErrText = e.Message;
                return null;
            }
        }

        #endregion
    }
}

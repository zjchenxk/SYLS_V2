using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InnoSoft.LS.Models;

namespace InnoSoft.LS.Data.Access
{
    public class DDDAO : BaseDAO
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Country> list = LoadData<Country>("LoadCountrys", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCountryId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Country> list = LoadData<Country>("LoadCountry", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("InsertCountry", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateCountry", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCountryId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteCountry", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCountryName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Province> list = LoadData<Province>("LoadProvincesByCountry", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 获取所有省份自定义数据
        /// </summary>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>省份自定义数据集</returns>
        public List<Province> LoadProvinces(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Province> list = LoadData<Province>("LoadProvinces", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nProvinceId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Province> list = LoadData<Province>("LoadProvince", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
					MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CountryName),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("InsertProvince", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
					MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CountryName),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateProvince", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nProvinceId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteProvince", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        #endregion

        #region 城市自定义代码

        /// <summary>
        /// 获取所有城市自定义数据
        /// </summary>
        /// <param name="nOpStaffId">操作员工编码</param>
        /// <param name="strOpStaffName">操作员工姓名</param>
        /// <param name="strErrText">出错信息</param>
        /// <returns>城市自定义数据集</returns>
        public List<City> LoadCitys(long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<City> list = LoadData<City>("LoadCitys", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCountryName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<City> list = LoadData<City>("LoadCitysByCountry", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCountryName),
                    MakeParam(PROVINCENAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strProvinceName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<City> list = LoadData<City>("LoadCitysByProvince", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCityId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<City> list = LoadData<City>("LoadCity", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
					MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CountryName),
					MakeParam(PROVINCENAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ProvinceName),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("InsertCity", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
					MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CountryName),
					MakeParam(PROVINCENAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ProvinceName),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateCity", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCityId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteCity", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<GoodsType> list = LoadData<GoodsType>("LoadGoodsTypes", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nTypeId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<GoodsType> list = LoadData<GoodsType>("LoadSubGoodsTypes", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nTypeId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<GoodsType> list = LoadData<GoodsType>("LoadGoodsType", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
					MakeParam(PARENTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.ParentId),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("InsertGoodsType", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
					MakeParam(PARENTID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.ParentId),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateGoodsType", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nTypeId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteGoodsType", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(TYPEID_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strTypeId),
					MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsNo),
					MakeParam(GOODSNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGoodsName),
					MakeParam(SPECMODEL_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strSpecModel),
					MakeParam(GWEIGHT_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGWeight),
					MakeParam(GRADE_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strGrade),
					MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strPacking),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Goods> list = LoadData<Goods>("LoadAllGoodsByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strGoodsNo),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Goods> list = LoadData<Goods>("LoadAllGoodsByGoodsNo", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Goods> list = LoadData<Goods>("LoadGoods", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strGoodsNo),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Goods> list = LoadData<Goods>("LoadGoodsByGoodsNo", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            long nId = 0;

            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)nId),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
					MakeParam(TYPEID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.TypeId),
					MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GoodsNo),
					MakeParam(SPECMODEL_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.SpecModel),
					MakeParam(GWEIGHT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GWeight??System.DBNull.Value),
					MakeParam(GRADE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Grade??System.DBNull.Value),
					MakeParam(BRAND_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Brand??System.DBNull.Value),
					MakeParam(PIECEWEIGHT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.PieceWeight??System.DBNull.Value),
					MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??System.DBNull.Value),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("InsertGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
					MakeParam(TYPEID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.TypeId),
					MakeParam(GOODSNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GoodsNo),
					MakeParam(SPECMODEL_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.SpecModel),
					MakeParam(GWEIGHT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.GWeight??System.DBNull.Value),
					MakeParam(GRADE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Grade??System.DBNull.Value),
					MakeParam(BRAND_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Brand??System.DBNull.Value),
					MakeParam(PIECEWEIGHT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.PieceWeight??System.DBNull.Value),
					MakeParam(PACKING_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.Packing??System.DBNull.Value),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteGoods", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Warehouse> list = LoadData<Warehouse>("LoadWarehouses", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Warehouse> list = LoadData<Warehouse>("LoadWarehouse", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
					MakeParam(ISLEASE_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsLease),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("InsertWarehouse", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
					MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
					MakeParam(ISLEASE_PARAM, SqlDbType.Bit, 1, ParameterDirection.Input, (object)data.IsLease),
					MakeParam(REMARK_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.Remark??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("UpdateWarehouse", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
					MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteWarehouse", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Carrier> list = LoadData<Carrier>("LoadCarriers", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Carrier> list = LoadData<Carrier>("LoadCarrier", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierCar> list = LoadData<CarrierCar>("LoadCarrierCars", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierDriver> list = LoadData<CarrierDriver>("LoadCarrierDrivers", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierSettlementExpression> list = LoadData<CarrierSettlementExpression>("LoadCarrierSettlementExpressions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierId),
                    MakeParam(PLANTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strPlanType),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierSettlementExpression> list = LoadData<CarrierSettlementExpression>("LoadCarrierSettlementExpression", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierTransportPrice> list = LoadData<CarrierTransportPrice>("LoadCarrierTransportPrices", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierId),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartCity),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestCountry),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestProvince),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestCity),
                    MakeParam(PLANTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strPlanType),
                    MakeParam(CREATETIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)dtCreateTime),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierTransportPrice> list = LoadData<CarrierTransportPrice>("LoadCarrierTransportPrice", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        /// <summary>
        /// 新增承运单位档案
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertCarrier(Carrier data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
                    MakeParam(BUSINESSTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.BusinessType),
                    MakeParam(PAYMENTTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PaymentType),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertCarrier", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 新增承运单位车辆信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertCarrierCar(CarrierCar data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CarNo),
                    MakeParam(TRAILERNO_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.TrailerNo??System.DBNull.Value),
                    MakeParam(CARRYINGCAPACITY_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.CarryingCapacity),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertCarrierCar", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改承运单位车辆信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateCarrierCar(CarrierCar data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.CarNo),
                    MakeParam(TRAILERNO_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.TrailerNo??System.DBNull.Value),
                    MakeParam(CARRYINGCAPACITY_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.CarryingCapacity),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateCarrierCar", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增承运单位驾驶员信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertCarrierDriver(CarrierDriver data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, -1, ParameterDirection.Input, (object)data.CarNo),
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Name),
                    MakeParam(LICENSENO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.LicenseNo),
                    MakeParam(MOBILETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.MobileTel),
                    MakeParam(HOMETEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.HomeTel??string.Empty),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertCarrierDriver", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增承运单位结算公式数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertCarrierSettlementExpression(CarrierSettlementExpression data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId),
                    MakeParam(PLANTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PlanType),
                    MakeParam(TRANSPORTCHARGEEXPRESSION_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.TransportChargeExpression),
                    MakeParam(TRANSPORTPRICEEXPRESSION_PARAM, SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)data.TransportPriceExpression),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertCarrierSettlementExpression", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增承运单位承运价格数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertCarrierTransportPrice(CarrierTransportPrice data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.CarrierId),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCity),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestCountry),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestProvince),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestCity),
                    MakeParam(PLANTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PlanType),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.StartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.EndTime),
                    MakeParam(TRANSPORTPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportPrice),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertCarrierTransportPrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增承运单位档案
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateCarrier(Carrier data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
                    MakeParam(BUSINESSTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.BusinessType),
                    MakeParam(PAYMENTTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PaymentType),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateCarrier", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定承运单位的所有车辆数据
        /// </summary>
        /// <param name="nCarrierId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCarrierCars(long nCarrierId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteCarrierCars", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除承运单位指定车辆数据
        /// </summary>
        /// <param name="nId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCarrierCar(long nId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteCarrierCar", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定承运单位的所有驾驶员数据
        /// </summary>
        /// <param name="nCarrierId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCarrierDrivers(long nCarrierId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteCarrierDrivers", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定承运单位的所有结算公式数据
        /// </summary>
        /// <param name="nCarrierId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCarrierSettlementExpressions(long nCarrierId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteCarrierSettlementExpressions", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除指定承运单位的所有承运价格数据
        /// </summary>
        /// <param name="nCarrierId"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteCarrierTransportPrices(long nCarrierId, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nCarrierId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteCarrierTransportPrices", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            if (Execute("DeleteCarrier", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierCar> list = LoadData<CarrierCar>("LoadCars", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierCar> list = LoadData<CarrierCar>("LoadCarsByCarNo", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Carrier> list = LoadData<Carrier>("LoadCarrierByCarNo", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierCar> list = LoadData<CarrierCar>("LoadCarByCarNo", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierDriver> list = LoadData<CarrierDriver>("LoadDriversByCarNo", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierDriver> list = LoadData<CarrierDriver>("LoadDriver", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CARRIERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarrierName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<CarrierCar> list = LoadData<CarrierCar>("LoadCarrierCarsByName", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(STARTTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strStartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strEndTime),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Carrier> list = LoadData<Carrier>("LoadGenerateBusinessCarriersByTimespan", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Carrier> list = LoadData<Carrier>("LoadCarrierByName", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strName),
                    MakeParam(CARNO_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCarNo),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Carrier> list = LoadData<Carrier>("LoadCarriersByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)strPlanType),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartCity),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestCountry),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestProvince),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strDestCity),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<TransportLimitedPrice> list = LoadData<TransportLimitedPrice>("LoadTransportLimitedPricesByConditions", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<TransportLimitedPrice> list = LoadData<TransportLimitedPrice>("LoadTransportLimitedPrice", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(PLANTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PlanType),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCity),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestCountry),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestProvince),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestCity),
                    MakeParam(CARTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.CarType??string.Empty),
                    MakeParam(MINTUNNAGESORPILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.MinTunnagesOrPiles),
                    MakeParam(MAXTUNNAGESORPILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.MaxTunnagesOrPiles),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.StartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.EndTime),
                    MakeParam(TRANSPORTPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportPrice),
                    MakeParam(TRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportCharges),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertTransportLimitedPrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(PLANTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.PlanType),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCity),
                    MakeParam(DESTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestCountry),
                    MakeParam(DESTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestProvince),
                    MakeParam(DESTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.DestCity),
                    MakeParam(CARTYPE_PARAM, SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)data.CarType??string.Empty),
                    MakeParam(MINTUNNAGESORPILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.MinTunnagesOrPiles),
                    MakeParam(MAXTUNNAGESORPILES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.MaxTunnagesOrPiles),
                    MakeParam(STARTTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.StartTime),
                    MakeParam(ENDTIME_PARAM, SqlDbType.DateTime, 8, ParameterDirection.Input, (object)data.EndTime),
                    MakeParam(TRANSPORTPRICE_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportPrice),
                    MakeParam(TRANSPORTCHARGES_PARAM, SqlDbType.Decimal, 13, ParameterDirection.Input, (object)data.TransportCharges),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateTransportLimitedPrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteTransportLimitedPrice", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Receiver> list = LoadData<Receiver>("LoadReceivers", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Receiver> list = LoadData<Receiver>("LoadReceiverNamesByName", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Receiver> list = LoadData<Receiver>("LoadReceiverByName", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(CUSTOMERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strCustomerName),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Receiver> list = LoadData<Receiver>("LoadCustomerReceivers", Params, out strErrText);
            return list;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strReceiverName),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)strStartCity),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ReceiverDistance> list = LoadData<ReceiverDistance>("LoadReceiverDistance", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(RECEIVERID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nReceiverId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<ReceiverDistance> list = LoadData<ReceiverDistance>("LoadReceiverDistances", Params, out strErrText);
            return list;
        }

        /// <summary>
        /// 新增收货单位数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public long InsertReceiver(Receiver data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Output, (object)data.Id),
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
                    MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Country),
                    MakeParam(PROVINCENAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Province),
                    MakeParam(CITYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.City),
                    MakeParam(ADDRESS_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Address),
                    MakeParam(RECEIVERCONTACT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Contact??System.DBNull.Value),
                    MakeParam(RECEIVERCONTACTTEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ContactTel??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            SqlParameterCollection outParams;
            if (Execute("InsertReceiver", Params, out outParams, out strErrText) < 0)
            {
                return 0;
            }
            else
            {
                return (long)outParams[ID_PARAM].Value;
            }
        }

        /// <summary>
        /// 修改收货单位数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool UpdateReceiver(Receiver data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)data.Id),
                    MakeParam(NAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Name),
                    MakeParam(COUNTRYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Country),
                    MakeParam(PROVINCENAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Province),
                    MakeParam(CITYNAME_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.City),
                    MakeParam(ADDRESS_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.Address),
                    MakeParam(RECEIVERCONTACT_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.Contact??System.DBNull.Value),
                    MakeParam(RECEIVERCONTACTTEL_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.ContactTel??System.DBNull.Value),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("UpdateReceiver", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteReceiver", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 新增收货单位距离数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool InsertReceiverDistance(ReceiverDistance data, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)data.ReceiverName),
                    MakeParam(STARTCOUNTRY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCountry),
                    MakeParam(STARTPROVINCE_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartProvince),
                    MakeParam(STARTCITY_PARAM, SqlDbType.NVarChar, 20, ParameterDirection.Input, (object)data.StartCity),
                    MakeParam(KM_PARAM, SqlDbType.Int, 4, ParameterDirection.Input, (object)data.KM),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("InsertReceiverDistance", Params, out strErrText) >= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除收货单位距离数据
        /// </summary>
        /// <param name="strReceiverName"></param>
        /// <param name="nOpStaffId"></param>
        /// <param name="strOpStaffName"></param>
        /// <param name="strErrText"></param>
        /// <returns></returns>
        public bool DeleteReceiverDistances(string strReceiverName, long nOpStaffId, string strOpStaffName, out string strErrText)
        {
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(RECEIVERNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strReceiverName),
					MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
					MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName),
				};

            if (Execute("DeleteReceiverDistances", Params, out strErrText) >= 0)
                return true;
            else
                return false;
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
            //创建存储过程参数
            SqlParameter[] Params =
				{
                    MakeParam(ID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nId),
                    MakeParam(OPSTAFFID_PARAM, SqlDbType.BigInt, 8, ParameterDirection.Input, (object)nOpStaffId),
                    MakeParam(OPSTAFFNAME_PARAM, SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)strOpStaffName)
				};

            List<Receiver> list = LoadData<Receiver>("LoadReceiver", Params, out strErrText);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        #endregion
    }
}

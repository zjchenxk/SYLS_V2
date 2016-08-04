using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace InnoSoft.LS.Business.Rules
{
    internal class Utils
    {
        /// <summary>
        /// 获取输入字符串的MD5码
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string GetMD5Hash(string strInput)
        {
            MD5 md5 = MD5.Create();

            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(strInput));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 计算条件组合表达式结果
        /// </summary>
        /// <param name="strConditionExpression">条件组合表达式</param>
        /// <returns></returns>
        public static bool CalculateApproveFlowStepConditionExpression(string strConditionExpression)
        {
            //1.处理表达式字符串
            //1.1.全部转换为小写
            strConditionExpression = strConditionExpression.ToLower();

            //1.2.将and和or转换为&和|
            strConditionExpression = strConditionExpression.Replace("and", "&");
            strConditionExpression = strConditionExpression.Replace("or", "|");

            //1.3.删除空格字符
            strConditionExpression = strConditionExpression.Replace(" ", "");

            //2.将中缀表达式转换成后缀表达式
            strConditionExpression = TransformPostFix(strConditionExpression);

            //3.运算后缀表达式
            Stack stack = new Stack();
            string[] arrayString = strConditionExpression.Split('$');
            foreach (string str in arrayString)
            {
                if (str == "true" || str == "false")
                {
                    stack.Push(Convert.ToBoolean(str));
                }
                else
                {
                    try
                    {
                        bool bRight = (bool)stack.Pop();
                        bool bLeft = (bool)stack.Pop();

                        switch (str)
                        {
                            case "&": stack.Push(bLeft && bRight); break;
                            case "|": stack.Push(bLeft || bRight); break;
                        }
                    }
                    catch (InvalidOperationException e)
                    {
                        stack.Clear();
                        throw new Exception(e.Message);
                    }
                }
            }
            return (bool)stack.Pop();
        }

        /// <summary>
        /// 将中缀表达式转换成后缀表达式
        /// </summary>
        /// <param name="strConditionExpression"></param>
        /// <returns></returns>
        private static string TransformPostFix(string strConditionExpression)
        {
            strConditionExpression = strConditionExpression + "#";

            Stack stack = new Stack();
            stack.Push('#');

            bool bIsLetter = false;
            string strTemp = string.Empty;
            string strResult = string.Empty;
            char chTemp;

            //扫描表达式字符串
            char[] arrayChars = strConditionExpression.ToCharArray();
            foreach (char c in arrayChars)
            {
                if (Char.IsLetter(c))
                {
                    strTemp += c.ToString();
                    bIsLetter = true;
                }
                else
                {
                    if (bIsLetter)
                    {
                        strResult += (strTemp + "$");
                        strTemp = string.Empty;
                        bIsLetter = false;
                    }
                    if (c == ')')
                    {
                        for (chTemp = Convert.ToChar(stack.Pop()); chTemp != '('; chTemp = Convert.ToChar(stack.Pop()))
                        {
                            strResult += (chTemp.ToString() + "$");
                        }
                    }
                    else
                    {
                        for (chTemp = Convert.ToChar(stack.Pop()); Isp(chTemp) > Icp(c); chTemp = Convert.ToChar(stack.Pop()))
                        {
                            strResult += (chTemp.ToString() + "$");
                        }
                        stack.Push(chTemp);
                        stack.Push(c);
                    }
                }
            }
            return strResult.Substring(0, strResult.Length - 1);
        }

        /// <summary>
        /// 获取栈内运算符优先级
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static int Isp(char c)
        {
            int k;
            switch (c)
            {
                case '#': k = 0; break;
                case '(': k = 1; break;
                case '&': k = 5; break;
                case '|': k = 3; break;
                case ')': k = 8; break;
                default:
                    throw new Exception(string.Format(InnoSoft.LS.Resources.Strings.IllegalOperator, c.ToString()));
            }
            return k;
        }

        /// <summary>
        /// 获取栈外运算符优先级
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static int Icp(char c)
        {
            int k;
            switch (c)
            {
                case '#': k = 0; break;
                case '(': k = 8; break;
                case '&': k = 4; break;
                case '|': k = 2; break;
                case ')': k = 1; break;
                default:
                    throw new Exception(string.Format(InnoSoft.LS.Resources.Strings.IllegalOperator, c.ToString()));
            }
            return k;
        }

    }
}

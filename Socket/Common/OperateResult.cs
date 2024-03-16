using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketTest.Common
{
    /// <summary>
    /// ���������
    /// </summary>
    public class OperateResult
    {

        /// <summary>
        /// ����Ƿ�ɹ�
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string Message { get; set; } = "UnKnownError";

        /// <summary>
        /// �������
        /// </summary>
        public int ErrorCode { get; set; } = 99999;

        /// <summary>
        /// ���췽��
        /// </summary>
        public OperateResult()
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�����Ƿ�ɹ�</param>
        public OperateResult(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�����Ƿ�ɹ�</param>
        /// <param name="message">�����Ϣ</param>
        public OperateResult(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�����Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">�����Ϣ</param>
        public OperateResult(bool isSuccess, int errorCode, string message)
        {
            this.IsSuccess = isSuccess;
            this.ErrorCode = errorCode;
            this.Message = message;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="message">�����Ϣ</param>
        public OperateResult(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="errorCode">�������</param>
        /// <param name="message">�����Ϣ</param>
        public OperateResult(int errorCode, string message)
        {
            this.ErrorCode = errorCode;
            this.Message = message;
        }

        /// <summary>
        /// ����һ�������ɹ����
        /// </summary>
        /// <returns></returns>
        public static OperateResult CreateSuccessResult()
        {
            return new OperateResult()
            {
                IsSuccess = true,
                ErrorCode = 0,
                Message = "Success",
            };
        }

        /// <summary>
        /// ����һ������ʧ�ܽ�����������Ϣ
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static OperateResult CreateFailResult(string message)
        {
            return new OperateResult()
            {
                IsSuccess = false,
                ErrorCode = 99999,
                Message = message,
            };
        }

        /// <summary>
        /// ����һ������ʧ�ܽ�������������Ϣ
        /// </summary>
        /// <returns></returns>
        public static OperateResult CreateFailResult()
        {
            return new OperateResult()
            {
                IsSuccess = false,
                ErrorCode = 99999,
                Message = "UnKnownError",
            };
        }

        /// <summary>
        /// ���ƴ�һ�����ݵĲ������
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <param name="result">�����������</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1> CopyOperateResult<T1,T2>(OperateResult<T2> result)
        {
            return new OperateResult<T1>()
            {
                IsSuccess = result.IsSuccess,
                ErrorCode = result.ErrorCode,
                Message = result.Message,
                Content= (T1)Convert.ChangeType(result.Content, typeof(T1))
            };
        }


        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="value">ֵ</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T> CreateSuccessResult<T>(T value)
        {
            return new OperateResult<T>()
            {
                IsSuccess = true,
                ErrorCode = 0,
                Message = "Success",
                Content = value
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ���ʧ�ܽ��
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="result">�����������</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T> CreateFailResult<T>(OperateResult result)
        {
            return new OperateResult<T>()
            {
                IsSuccess = false,
                ErrorCode = result.ErrorCode,
                Message = result.Message
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ���ʧ�ܽ��
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="message">������Ϣ</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T> CreateFailResult<T>(string message)
        {
            return new OperateResult<T>()
            {
                IsSuccess = false,
                ErrorCode = 99999,
                Message = message
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <param name="value1">ֵ1</param>
        /// <param name="value2">ֵ2</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2> CreateSuccessResult<T1, T2>(T1 value1, T2 value2)
        {
            return new OperateResult<T1, T2>()
            {
                IsSuccess = true,
                ErrorCode = 0,
                Message = "Success",
                Content1 = value1,
                Content2 = value2
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ���ʧ�ܽ��
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <param name="result">�������</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2> CreateFailResult<T1, T2>(OperateResult result)
        {
            return new OperateResult<T1, T2>()
            {
                IsSuccess = false,
                ErrorCode = result.ErrorCode,
                Message = result.Message
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ���ʧ�ܽ��
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <param name="message">������Ϣ</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2> CreateFailResult<T1, T2>(string message)
        {
            return new OperateResult<T1, T2>()
            {
                IsSuccess = false,
                ErrorCode = 99999,
                Message = message
            };
        }


        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <typeparam name="T3">����3</typeparam>
        /// <param name="value1">ֵ1</param>
        /// <param name="value2">ֵ2</param>
        /// <param name="value3">ֵ3</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2, T3> CreateSuccessResult<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
        {
            return new OperateResult<T1, T2, T3>()
            {
                IsSuccess = true,
                ErrorCode = 0,
                Message = "Success",
                Content1 = value1,
                Content2 = value2,
                Content3 = value3
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <typeparam name="T3">����3</typeparam>
        /// <param name="result">�������</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2, T3> CreateFailResult<T1, T2, T3>(OperateResult result)
        {
            return new OperateResult<T1, T2, T3>()
            {
                IsSuccess = false,
                ErrorCode = result.ErrorCode,
                Message = result.Message
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <typeparam name="T3">����3</typeparam>
        /// <param name="message">������Ϣ</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2, T3> CreateFailResult<T1, T2, T3>(string message)
        {
            return new OperateResult<T1, T2, T3>()
            {
                IsSuccess = false,
                ErrorCode = 99999,
                Message = message
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <typeparam name="T3">����3</typeparam>
        /// <typeparam name="T4">����4</typeparam>
        /// <param name="value1">ֵ1</param>
        /// <param name="value2">ֵ2</param>
        /// <param name="value3">ֵ3</param>
        /// <param name="value4">ֵ4</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2, T3, T4> CreateSuccessResult<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            return new OperateResult<T1, T2, T3, T4>()
            {
                IsSuccess = true,
                ErrorCode = 0,
                Message = "Success",
                Content1 = value1,
                Content2 = value2,
                Content3 = value3,
                Content4 = value4
            };
        }


        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <typeparam name="T3">����3</typeparam>
        /// <typeparam name="T4">����4</typeparam>
        /// <param name="result">�������</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2, T3, T4> CreateFailResult<T1, T2, T3, T4>(OperateResult result)
        {
            return new OperateResult<T1, T2, T3, T4>()
            {
                IsSuccess = false,
                ErrorCode = result.ErrorCode,
                Message = result.Message
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <typeparam name="T3">����3</typeparam>
        /// <typeparam name="T4">����4</typeparam>
        /// <param name="message">������Ϣ</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2, T3, T4> CreateFailResult<T1, T2, T3, T4>(string message)
        {
            return new OperateResult<T1, T2, T3, T4>()
            {
                IsSuccess = false,
                ErrorCode = 99999,
                Message = message
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <typeparam name="T3">����3</typeparam>
        /// <typeparam name="T4">����4</typeparam>
        /// <typeparam name="T5">����5</typeparam>
        /// <param name="value1">ֵ1</param>
        /// <param name="value2">ֵ2</param>
        /// <param name="value3">ֵ3</param>
        /// <param name="value4">ֵ4</param>
        /// <param name="value5">ֵ5</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2, T3, T4, T5> CreateSuccessResult<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            return new OperateResult<T1, T2, T3, T4, T5>()
            {
                IsSuccess = true,
                ErrorCode = 0,
                Message = "Success",
                Content1 = value1,
                Content2 = value2,
                Content3 = value3,
                Content4 = value4,
                Content5 = value5
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <typeparam name="T3">����3</typeparam>
        /// <typeparam name="T4">����4</typeparam>
        /// <typeparam name="T5">����5</typeparam>
        /// <param name="result">�������</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2, T3, T4, T5> CreateFailResult<T1, T2, T3, T4, T5>(OperateResult result)
        {
            return new OperateResult<T1, T2, T3, T4, T5>()
            {
                IsSuccess = false,
                ErrorCode = result.ErrorCode,
                Message = result.Message
            };
        }

        /// <summary>
        /// ������һ�����ݵĲ����ɹ����
        /// </summary>
        /// <typeparam name="T1">����1</typeparam>
        /// <typeparam name="T2">����2</typeparam>
        /// <typeparam name="T3">����3</typeparam>
        /// <typeparam name="T4">����4</typeparam>
        /// <typeparam name="T5">����5</typeparam>
        /// <param name="message">������Ϣ</param>
        /// <returns>��һ�����ݵĲ������</returns>
        public static OperateResult<T1, T2, T3, T4, T5> CreateFailResult<T1, T2, T3, T4, T5>(string message)
        {
            return new OperateResult<T1, T2, T3, T4, T5>()
            {
                IsSuccess = false,
                ErrorCode = 99999,
                Message = message
            };
        }
    }

    /// <summary>
    /// ��һ�����ݵĲ��������
    /// </summary>
    /// <typeparam name="T">����</typeparam>
    public class OperateResult<T> : OperateResult
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public OperateResult() : base()
        {
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�����Ƿ�ɹ�</param>
        public OperateResult(bool isSuccess) : base(isSuccess)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="message">������Ϣ</param>
        public OperateResult(string message) : base(message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        public OperateResult(int errorCode, string message) : base(errorCode, message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        public OperateResult(bool isSuccess, int errorCode, string message) : base(isSuccess, errorCode, message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        /// <param name="content">����</param>
        public OperateResult(bool isSuccess, int errorCode, string message, T content) : base(isSuccess, errorCode, message)
        {
            this.Content = content;
        }


        /// <summary>
        ///  ����
        /// </summary>
        public T Content { get; set; }

    }

    /// <summary>
    /// ���������ݵĲ��������
    /// </summary>
    /// <typeparam name="T1">����1</typeparam>
    /// <typeparam name="T2">����2</typeparam>
    public class OperateResult<T1, T2> : OperateResult
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public OperateResult() : base()
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�����Ƿ�ɹ�</param>
        public OperateResult(bool isSuccess) : base(isSuccess)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="message">������Ϣ</param>
        public OperateResult(string message) : base(message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        public OperateResult(int errorCode, string message) : base(errorCode, message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        public OperateResult(bool isSuccess, int errorCode, string message) : base(isSuccess, errorCode, message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        /// <param name="content1">����1</param>
        /// <param name="content2">����2</param>
        public OperateResult(bool isSuccess, int errorCode, string message, T1 content1, T2 content2) : base(isSuccess, errorCode, message)
        {
            this.Content1 = content1;
            this.Content2 = content2;
        }


        /// <summary>
        /// ����1
        /// </summary>
        public T1 Content1 { get; set; }

        /// <summary>
        /// ����2
        /// </summary>
        public T2 Content2 { get; set; }

    }

    /// <summary>
    /// ���������ݵĲ��������
    /// </summary>
    /// <typeparam name="T1">����1</typeparam>
    /// <typeparam name="T2">����2</typeparam>
    /// <typeparam name="T3">����3</typeparam>
    public class OperateResult<T1, T2, T3> : OperateResult
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public OperateResult() : base()
        {

        }


        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�����Ƿ�ɹ�</param>
        public OperateResult(bool isSuccess) : base(isSuccess)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="message">������Ϣ</param>
        public OperateResult(string message) : base(message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        public OperateResult(int errorCode, string message) : base(errorCode, message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        public OperateResult(bool isSuccess, int errorCode, string message) : base(isSuccess, errorCode, message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        /// <param name="content1">����1</param>
        /// <param name="content2">����2</param>
        /// <param name="content3">����3</param>
        public OperateResult(bool isSuccess, int errorCode, string message, T1 content1, T2 content2, T3 content3) : base(isSuccess, errorCode, message)
        {
            this.Content1 = content1;
            this.Content2 = content2;
            this.Content3 = content3;
        }

        /// <summary>
        /// ����1
        /// </summary>
        public T1 Content1 { get; set; }

        /// <summary>
        /// ����2
        /// </summary>
        public T2 Content2 { get; set; }

        /// <summary>
        /// ����3
        /// </summary>
        public T3 Content3 { get; set; }

    }


    /// <summary>
    /// ���ĸ����ݵĲ��������
    /// </summary>
    /// <typeparam name="T1">����1</typeparam>
    /// <typeparam name="T2">����2</typeparam>
    /// <typeparam name="T3">����3</typeparam>
    /// <typeparam name="T4">����4</typeparam>
    public class OperateResult<T1, T2, T3, T4> : OperateResult
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public OperateResult() : base()
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�����Ƿ�ɹ�</param>
        public OperateResult(bool isSuccess) : base(isSuccess)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="message">������Ϣ</param>
        public OperateResult(string message) : base(message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        public OperateResult(int errorCode, string message) : base(errorCode, message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        public OperateResult(bool isSuccess, int errorCode, string message) : base(isSuccess, errorCode, message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        /// <param name="content1">����1</param>
        /// <param name="content2">����2</param>
        /// <param name="content3">����3</param>
        /// <param name="content4">����4</param>
        public OperateResult(bool isSuccess, int errorCode, string message, T1 content1, T2 content2, T3 content3, T4 content4) : base(isSuccess, errorCode, message)
        {
            this.Content1 = content1;
            this.Content2 = content2;
            this.Content3 = content3;
            this.Content4 = content4;
        }

        /// <summary>
        /// ����1
        /// </summary>
        public T1 Content1 { get; set; }

        /// <summary>
        /// ����2
        /// </summary>
        public T2 Content2 { get; set; }

        /// <summary>
        /// ����3
        /// </summary>
        public T3 Content3 { get; set; }

        /// <summary>
        /// ����4
        /// </summary>
        public T4 Content4 { get; set; }

    }

    /// <summary>
    /// ��������ݵĲ��������
    /// </summary>
    /// <typeparam name="T1">����1</typeparam>
    /// <typeparam name="T2">����2</typeparam>
    /// <typeparam name="T3">����3</typeparam>
    /// <typeparam name="T4">����4</typeparam>
    /// <typeparam name="T5">����5</typeparam>
    public class OperateResult<T1, T2, T3, T4, T5> : OperateResult
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public OperateResult() : base()
        {
        }


        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�����Ƿ�ɹ�</param>
        public OperateResult(bool isSuccess) : base(isSuccess)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="message">������Ϣ</param>
        public OperateResult(string message) : base(message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        public OperateResult(int errorCode, string message) : base(errorCode, message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        public OperateResult(bool isSuccess, int errorCode, string message) : base(isSuccess, errorCode, message)
        {

        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="isSuccess">�Ƿ�ɹ�</param>
        /// <param name="errorCode">�������</param>
        /// <param name="message">������Ϣ</param>
        /// <param name="content1">����1</param>
        /// <param name="content2">����2</param>
        /// <param name="content3">����3</param>
        /// <param name="content4">����4</param>
        /// <param name="content5">����5</param>
        public OperateResult(bool isSuccess, int errorCode, string message, T1 content1, T2 content2, T3 content3, T4 content4, T5 content5) : base(isSuccess, errorCode, message)
        {
            this.Content1 = content1;
            this.Content2 = content2;
            this.Content3 = content3;
            this.Content4 = content4;
            this.Content5 = content5;
        }

        /// <summary>
        /// ����1
        /// </summary>
        public T1 Content1 { get; set; }

        /// <summary>
        /// ����2
        /// </summary>
        public T2 Content2 { get; set; }

        /// <summary>
        /// ����3
        /// </summary>
        public T3 Content3 { get; set; }

        /// <summary>
        /// ����4
        /// </summary>
        public T4 Content4 { get; set; }

        /// <summary>
        /// ����5
        /// </summary>
        public T5 Content5 { get; set; }


    }

}
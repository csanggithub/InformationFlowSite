using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationFlow.Entity.Domain
{
    [Table("sendsmslog")]
    public class SendSmsLog
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerCode { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 请求ID
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 发送回执ID,可根据该ID查询具体的发送状态
        /// </summary>
        public string BizId { get; set; }

        /// <summary>
        /// 状态码-返回OK代表请求成功,其他错误码详见错误码列表
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 状态码的描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Createtime { get; set; }
    }
}

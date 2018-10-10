using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationFlow.Entity.Domain
{
    [Table("messageboard")]
    public class MessageBoard
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        public string MessageContent { get; set; }

        /// <summary>
        /// 本地IP
        /// </summary>
        public string LocalIp { get; set; }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIp { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 获取当前页面url 
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// Url来源途径，获取上一页面url
        /// </summary>
        public string UrlReferrer { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}

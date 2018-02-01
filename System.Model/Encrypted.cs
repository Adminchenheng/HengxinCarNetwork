using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 密保问题
    /// </summary>
    public class Encrypted
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string EncryptedID { get; set; }
        /// <summary>
        /// 问题一
        /// </summary>
        public string QuestionOne { get; set; }
        /// <summary>
        /// 问题二
        /// </summary>
        public string QuestionTow { get; set; }
        /// <summary>
        /// 问题三
        /// </summary>
        public string QuestionThree { get; set; }
        /// <summary>
        /// 关联答案表
        /// </summary>
        public string AnswerID { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Model
{
    /// <summary>
    /// 密保答案
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string AnswerID { get; set; }
        /// <summary>
        /// 答案一
        /// </summary>
        public string AnswerOne { get; set; }
        /// <summary>
        /// 答案二
        /// </summary>
        public string AnswerTow { get; set; }
        /// <summary>
        /// 答案三
        /// </summary>
        public string AnswerThree { get; set; }        
    }
}

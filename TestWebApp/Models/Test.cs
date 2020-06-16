using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class Test
    {
        /// <summary>
        /// 会社名
        /// </summary>
        [Display(Name = "会社名")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [MaxLength(10, ErrorMessage = "{0}は10文字までです。")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 会社名（フリガナ）
        /// </summary>
        [Required]
        [StringLength(40)]
        [Display(Name = "フリガナ")]
        public string CompanyPhonetic { get; set; }

        /// <summary>
        /// 部署名
        /// </summary>
        [Display(Name = "部署名コード")]
        [StringLength(40)]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 部署名
        /// </summary>
        [Display(Name = "部署名")]
        [StringLength(40)]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 郵便番号
        /// </summary>
        [StringLength(40)]
        [Display(Name = "郵便番号")]
        public string PostCode { get; set; }

        /// <summary>
        /// 都道府県
        /// </summary>
        [StringLength(40)]
        [Display(Name = "都道府県")]
        public string Prefectures { get; set; }

        /// <summary>
        /// 市区町村
        /// </summary>
        [StringLength(40)]
        [Display(Name = "市区町村")]
        public string Municipalities { get; set; }

        /// <summary>
        /// 番地
        /// </summary>
        [StringLength(40)]
        [Display(Name = "番地")]
        public string Block { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        [Required]
        [StringLength(40)]
        [Display(Name = "電話番号")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// FAX番号
        /// </summary>
        [StringLength(40)]
        [Display(Name = "FAX番号")]
        public string FaxNumber { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        [StringLength(40)]
        [Required]
        [Display(Name = "メールアドレス")]
        public string MailAddress { get; set; }
    }
}
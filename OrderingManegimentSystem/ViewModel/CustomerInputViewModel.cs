using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OrderingManegimentSystem.Models;


namespace OrderingManegimentSystem.ViewModel
{
    public class CustomerInputViewModel
    {
        [DisplayName("顧客ID")]
        public int CustomerId { get; set; }

        [DisplayName("パスワード")]
        public string Password { get; set; }

        [DisplayName("会社名")]
        public string CompanyName { get; set; }

        [DisplayName("住所")]
        public string Address { get; set; }

        [DisplayName("電話番号")]
        public string Telno { get; set; }

        [DisplayName("氏名（漢字）")]
        public string CustomerName { get; set; }

        [DisplayName("氏名（かな）")]
        public string CustomerKana { get; set; }

        [DisplayName("部署")]
        public string Dept { get; set; }

        [DisplayName("メールアドレス")]
        public string Email { get; set; }

        [DisplayName("パスワード（確認）")]
        [Compare("Password", ErrorMessage = "パスワードとパスワード(確認)が一致しない。")]
        public string Password_verify { get; set; }

        public CustomerInputViewModel() { }

        public CustomerInputViewModel(Customer ctm)
        {
            this.CustomerId = ctm.CustomerId;
            this.CompanyName = ctm.CompanyName;
            this.Address = ctm.Address;
            this.Telno = ctm.Telno;
            this.CustomerName = ctm.CustomerName;
            this.CustomerKana = ctm.CustomerKana;
            this.Dept = ctm.Dept;
            this.Email = ctm.Email;
            this.Password = ctm.Password;
        }
    }
}
﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Convenience.Models.ViewModels.Chumon {
    /// <summary>
    /// 注文キービューモデル
    /// </summary>
    public class ChumonKeysViewModel {

        [Column("shiire_saki_code")]
        [DisplayName("仕入先コード")]
        [MaxLength(10)]
        [Required]
        public string ShiireSakiId { get; set; }

        [Column("chumon_date")]
        [DisplayName("注文日")]
        public DateOnly ChumonDate { get; set; }

        /// <summary>
        /// 仕入先一覧
        /// </summary>
        public List<SelectListItem>? ShiireSakiList { get; set; }
    }
}
﻿using Convenience.Data;
using Convenience.Models.DataModels;
using Convenience.Models.Interfaces;
using Convenience.Models.Properties;
using Convenience.Models.ViewModels.Shiire;
using Microsoft.AspNetCore.Mvc;
using static Convenience.Models.Properties.Message;

namespace Convenience.Controllers {

    /// <summary>
    /// 仕入サービスクラス
    /// </summary>
    public class ShiireController : Controller, ISharedTools {
        private readonly ConvenienceContext _context;

        private readonly IShiireService shiireService;

        private static readonly string IndexName = "ShiireViewModel";

        private ShiireViewModel shiireViewModel;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="context">DBコンテキスト</param>
        /// <param name="shiireService">仕入サービスクラスＤＩ注入用</param>
        public ShiireController(ConvenienceContext context,IShiireService shiireService) {
            this._context = context;
            this.shiireService = shiireService;
            //shiireService = new ShiireService(_context);
        }

        /// <summary>
        /// 仕入画面１枚目の初期表示
        /// </summary>
        /// <returns>ShiireKeysViewModel 仕入キービューモデル</returns>
        public async Task<IActionResult> ShiireKeyInput() {
            ShiireKeysViewModel keymodel = await shiireService.SetShiireKeysModel();
            return View(keymodel);
        }

        /// <summary>
        /// 仕入画面１枚目のPost後処理→仕入画面２枚目に遷移
        /// </summary>
        /// <param name="inKeysModel">仕入画面１枚目のpostデータ</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShiireKeyInput(ShiireKeysViewModel inKeysModel) {
            shiireViewModel = await shiireService.ShiireSetting(inKeysModel);
            ViewBag.HandlingFlg = "FirstDisplay";
            return View("Shiire", shiireViewModel);
        }
        /// <summary>
        /// 仕入画面２枚目のPost後処理
        /// </summary>
        /// <param name="inShiireViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Shiire(ShiireViewModel inShiireViewModel) {
            ModelState.Clear();

            var shiireViewModel = await shiireService.ShiireCommit(inShiireViewModel);

            ViewBag.HandlingFlg = "SecondDisplay";

            TempData[IndexName] = ISharedTools.ConvertToSerial(shiireViewModel);
            return RedirectToAction("Result");
        }
        /// <summary>
        /// 仕入画面２枚目の初期表示（仕入画面２枚目のPost後処理よりredirect）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Result() {
            ViewBag.HandlingFlg = "SecondDisplay";
            if (TempData.Peek(IndexName) != null) {
                shiireViewModel = ISharedTools.ConvertFromSerial<ShiireViewModel>(TempData[IndexName] as string);
                TempData[IndexName] = ISharedTools.ConvertToSerial(shiireViewModel);
                return View("Shiire", shiireViewModel);
            }
            else {
                return RedirectToAction("Shiire");
            }
        }


    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BudgetManager.Business.BusinessLogic;
using BudgetManager.Business.Services;
using BudgetManager.Domain;

namespace BudgetManager.Web.Controllers.api
{
    [System.Web.Http.RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAccountBusinessLogic _accountBusinessLogic;
        private IAccountDataService _accountDataService;

        public AccountController()
        {
            _accountBusinessLogic = new AccountBusinessLogic(new AccountDataService(new BudgetManagerDbContext()));
            _accountDataService = new AccountDataService(new BudgetManagerDbContext());
        }

        public AccountController(IAccountBusinessLogic accountBusinessLogic, IAccountDataService accountDataService)
        {
            _accountBusinessLogic = accountBusinessLogic;
            _accountDataService = accountDataService;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetAll")]
        public IEnumerable<Account> GetAll()
        {
            return this._accountDataService.GetAllAccounts();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Update")]
        public ActionResult Update(Account account)
        {
            this._accountBusinessLogic.Update(account);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Get")]
        public Account Get(int id)
        {
            var model = this._accountBusinessLogic.GetAccountDetails(id);
            return model;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Add")]
        public ActionResult Add(Account account)
        {
            this._accountBusinessLogic.Add(account);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

    }
}
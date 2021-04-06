using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Enums;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    public class DropdownController : BaseApiController
    {
        [HttpGet]
        [Route("months")]
        public ActionResult<DropdownDto> GetMonths()
        {
            return new DropdownDto()
            {
                DropdownDictionary = EnumToDictionary<EMonth>()
            };
        }

        [HttpGet]
        [Route("income-categories")]
        public ActionResult<DropdownDto> GetIncomeCategories()
        {
            return new DropdownDto()
            {
                DropdownDictionary = EnumToDictionary<EIncomeCategory>()
            };
        }

        [HttpGet]
        [Route("spending-categories")]
        public ActionResult<DropdownDto> GetSpendingCategories()
        {
            return new DropdownDto()
            {
                DropdownDictionary = EnumToDictionary<ESpendingCategory>()
            };
        }

        [HttpGet]
        [Route("saving-types")]
        public ActionResult<DropdownDto> GetSavingTypes()
        {
            return new DropdownDto()
            {
                DropdownDictionary = EnumToDictionary<ESavingType>()
            };
        }

        [HttpGet]
        [Route("vehicle-spending-categories")]
        public ActionResult<DropdownDto> GetVehicleSpendingCategories()
        {
            return new DropdownDto()
            {
                DropdownDictionary = EnumToDictionary<EVehicleSpendingCategory>()
            };
        }

        private static Dictionary<int, string> EnumToDictionary<E>()
        {
            var dictionary = new Dictionary<int, string>();

            foreach (var value in Enum.GetValues(typeof(E)))
            {
                dictionary.Add((int)value, value.ToString());
            }

            return dictionary;
        }
    }
}

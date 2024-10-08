﻿//using System.ComponentModel.DataAnnotations;

namespace VATCalculator.Models
{
    /// <summary>
    /// Model for display of price VAT related values
    /// </summary>
    public class PriceModel
    {
        /// <summary>
        /// Total monetary value without VAT
        /// </summary>
        public decimal PriceBase { get; set; }

        /// <summary>
        /// VAT monetary value
        /// </summary>
        public decimal VatAmount { get; set; }

        /// <summary>
        /// Total monetary value with VAT
        /// </summary>
        public decimal PriceTotal { get; set; }
    }
}

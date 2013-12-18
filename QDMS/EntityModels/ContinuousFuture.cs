﻿// -----------------------------------------------------------------------
// <copyright file="ContinuousFuture.cs" company="">
// Copyright 2013 Alexander Soffronow Pagonidis
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProtoBuf;

namespace QDMS
{
    [ProtoContract]
    [Serializable]
    public class ContinuousFuture
    {
        public ContinuousFuture()
        {
            UseJan = true;
            UseFeb = true;
            UseMar = true;
            UseApr = true;
            UseMay = true;
            UseJun = true;
            UseJul = true;
            UseAug = true;
            UseSep = true;
            UseOct = true;
            UseNov = true;
            UseDec = true;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ProtoMember(1)]
        public int ID { get; set; }

        [ProtoMember(2)]
        public int InstrumentID { get; set; }

        public virtual Instrument Instrument { get; set; }


        [ProtoMember(3)]
        public int UnderlyingSymbolID { get; set; }

        /// <summary>
        /// The underlying symbol that the continuous future is based on.
        /// </summary>
        public virtual UnderlyingSymbol UnderlyingSymbol { get; set; }

        /// <summary>
        /// Which contract month to use to construct the continuous prices.
        /// For example, Month = 1 uses the "front" future, Month = 2 uses the next one and so forth.
        /// </summary>
        [ProtoMember(4)]
        public int Month { get; set; }

        /// <summary>
        /// What criteria should be used when determining whether to roll over to the next contract.
        /// </summary>
        [ProtoMember(5)]
        public ContinuousFuturesRolloverType RolloverType { get; set; }

        /// <summary>
        /// Number of days that the criteria will use to determine rollover.
        /// </summary>
        [ProtoMember(6)]
        public int RolloverDays { get; set; }

        /// <summary>
        /// How to adjust prices from one contract to the next
        /// </summary>
        [ProtoMember(7)]
        public ContinuousFuturesAdjustmentMode AdjustmentMode { get; set; }

        [ProtoMember(8)]
        public bool UseJan { get; set; }

        [ProtoMember(9)]
        public bool UseFeb { get; set; }

        [ProtoMember(10)]
        public bool UseMar { get; set; }

        [ProtoMember(11)]
        public bool UseApr { get; set; }

        [ProtoMember(12)]
        public bool UseMay { get; set; }

        [ProtoMember(13)]
        public bool UseJun { get; set; }

        [ProtoMember(14)]
        public bool UseJul { get; set; }

        [ProtoMember(15)]
        public bool UseAug { get; set; }

        [ProtoMember(16)]
        public bool UseSep { get; set; }

        [ProtoMember(17)]
        public bool UseOct { get; set; }

        [ProtoMember(18)]
        public bool UseNov { get; set; }

        [ProtoMember(19)]
        public bool UseDec { get; set; }

        public bool MonthIsUsed(int month)
        {
            switch (month)
            {
                case 1:
                    return UseJan;
                case 2:
                    return UseFeb;
                case 3:
                    return UseMar;
                case 4:
                    return UseApr;
                case 5:
                    return UseMay;
                case 6:
                    return UseJun;
                case 7:
                    return UseJul;
                case 8:
                    return UseAug;
                case 9:
                    return UseSep;
                case 10:
                    return UseOct;
                case 11:
                    return UseNov;
                case 12:
                    return UseDec;
                default:
                    return false;
            }
        }

        //TODO is this the appropriate place for this method? Probably not...
        public int GetContractMonth(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

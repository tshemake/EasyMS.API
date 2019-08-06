using System;
using System.Collections.Generic;
using System.Text;
using EasyMS.API.Entities.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EasyMS.API.Entities
{
    public class Room
    {
        /// <summary>
        /// уникальный идентификатор комнаты в заказе
        /// </summary>
        [JsonProperty("roomReservationId")]
        public string RoomReservationId { get; set; }

        /// <summary>
        /// комната в объекте, где проживает гость
        /// </summary>
        [JsonProperty("roomId")]
        public string RoomId { get; set; }

        /// <summary>
        /// категория в объекте, где проживает гость
        /// </summary>
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        /// <summary>
        /// дата заезда
        /// </summary>
        [JsonProperty("arrival")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Arrival { get; set; }

        /// <summary>
        /// дата выезда
        /// </summary>
        [JsonProperty("departure")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Departure { get; set; }

        /// <summary>
        /// имя гостя
        /// </summary>
        [JsonProperty("guestName")]
        public string GuestName { get; set; }

        /// <summary>
        /// идентификатор тарифного плана
        /// </summary>
        [JsonProperty("rateId")]
        public int RateId { get; set; }

        /// <summary>
        /// статус “комнаты” в заказе
        /// </summary>
        [JsonProperty("status")]
        public RoomStatus Status { get; set; }

        /// <summary>
        /// валюта
        /// </summary>
        [JsonProperty("currencyCode")]
        public Currency CurrencyCode { get; set; }

        /// <summary>
        /// счет за “комнату”
        /// </summary>
        [JsonProperty("invoice")]
        public int Invoice { get; set; }

        /// <summary>
        /// уже оплачено
        /// </summary>
        [JsonProperty("paid")]
        public int Paid { get; set; }

        [JsonProperty("detailed")]
        public bool Detailed { get; set; }
    }
}

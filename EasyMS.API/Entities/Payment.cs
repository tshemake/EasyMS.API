using System;
using System.Collections.Generic;
using System.Text;
using EasyMS.API.Entities.Enums;
using EasyMS.API.Exceptions;
using EasyMS.API.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EasyMS.API.Entities
{
    public class Payment : Entity
    {
        /// <summary>
        /// идентификатор организации
        /// </summary>
        [JsonProperty("organizationId")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// идентификатор заказа
        /// </summary>
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// идентификатор комнаты в заказе
        /// </summary>
        [JsonProperty("roomReservationId")]
        public string RoomReservationId { get; set; }

        /// <summary>
        /// имя плательщика
        /// </summary>
        [JsonProperty("bookerName")]
        public string BookerName { get; set; }

        /// <summary>
        /// сумма платежа
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }

        /// <summary>
        /// тип оплаты
        /// </summary>
        [JsonProperty("payMethod")]
        public PayMethod PayMethod { get; set; }

        /// <summary>
        /// вручную указанное время оплаты
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Time { get; set; }

        /// <summary>
        /// подтверждена ли оплата
        /// </summary>
        [JsonProperty("accepted")]
        public bool Accepted { get; set; }

        /// <summary>
        /// возврат (true для проведения возврата)
        /// </summary>
        [JsonProperty("refund")]
        public bool Refund { get; set; }

        [JsonProperty("actionUserId", NullValueHandling = NullValueHandling.Ignore)]
        public string ActionUserId { get; set; }

        public void ValidateCreate()
        {
            var messages = new ValidationMessages();

            if (string.IsNullOrEmpty(OrganizationId))
            {
                messages.Add("OrganizationId пропущен. Используйте OrganizationId свойство чтобы установить organizationId.");
            }

            if (string.IsNullOrEmpty(OrderId))
            {
                messages.Add("OrderId пропущен. Используйте OrderId свойство чтобы установить orderId.");
            }

            if (string.IsNullOrEmpty(RoomReservationId))
            {
                messages.Add("RoomReservationId пропущен. Используйте RoomReservationId свойство чтобы установить roomReservationId.");
            }

            if (string.IsNullOrEmpty(BookerName))
            {
                messages.Add("BookerName пропущен. Используйте BookerName свойство чтобы установить bookerName.");
            }

            if (Value < 1)
            {
                messages.Add("Value пропущен. Используйте Value свойство чтобы установить value.");
            }

            if (PayMethod == PayMethod.None)
            {
                messages.Add("PayMethod не может быть 'none'.");
            }

            if (messages.HasErrors)
            {
                throw new EasyMSValidationException(messages);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EasyMS.API.Entities
{
    public sealed class Order : Entity
    {
        /// <summary>
        /// идентификатор организации
        /// </summary>
        [JsonProperty("organizationId")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// клиент, который делал заказ
        /// </summary>
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// массив “комнат” в заказе
        /// </summary>
        [JsonProperty("rooms")]
        public IReadOnlyCollection<Room> Rooms { get; set; }

        [JsonProperty("services")]
        public object[] Services { get; set; }

        /// <summary>
        /// время создания заказа
        /// </summary>
        [JsonProperty("bookedAt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? BookedAt { get; set; }

        /// <summary>
        /// время последнего изменения заказа
        /// </summary>
        [JsonProperty("modifiedAt")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// источник заказа
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }
    }
}

using Newtonsoft.Json;

namespace Conway.InterimPods.Core.Entities
{
    public class PodScan
    {
        [JsonProperty("ps_id")]
        public int Id { get; set; }  // PS_ID

        [JsonProperty("ps_date_processed")]
        public DateTime DateProcessed { get; set; }  // PS_DATE_PROCESSED

        [JsonProperty("ps_url")]
        public string? SharePointUrl { get; set; }  // PS_URL

        [JsonProperty("ps_order_id")]
        public int? OrderId { get; set; }  // PS_ORDER_ID

        [JsonProperty("ps_ticket_id")]
        public int? TicketId { get; set; }  // PS_TICKET_ID

        [JsonProperty("ps_loaded_at")]
        public string? LoadedAt { get; set; }  // PS_LOADED_AT

        [JsonProperty("ps_loaded_at_confidence")]
        public int? LoadedAtConfidence { get; set; } // PS_LOADED_AT_CONFIDENCE

        [JsonProperty("ps_file_name")]
        public string? FileName { get; set; }  // PS_FILE_NAME

        [JsonProperty("ps_message")]
        public string? Message { get; set; }  // PS_MESSAGE

        [JsonProperty("ps_time_on_site")]
        public string? TimeOnSite { get; set; }  // PS_TIME_ON_SITE

        [JsonProperty("ps_time_on_site_confidence")]
        public int? TimeOnSiteConfidence { get; set; } // PS_TIME_ON_SITE_CONFIDENCE

        [JsonProperty("ps_start_offload")]
        public string? StartOffload { get; set; }  // PS_START_OFFLOAD

        [JsonProperty("ps_start_offload_confidence")]
        public int? StartOffloadConfidence { get; set; } // PS_START_OFFLOAD_CONFIDENCE

        [JsonProperty("ps_time_off_site")]
        public string? TimeOffSite { get; set; }  // PS_TIME_OFF_SITE

        [JsonProperty("ps_time_off_site_confidence")]
        public int? TimeOffSiteConfidence { get; set; } // PS_TIME_OFF_SITE_CONFIDENCE

        [JsonProperty("ps_scanned_document")]
        public byte[]? ScannedDocument { get; set; } // PS_SCANNED_DOCUMENT

        [JsonProperty("ps_scan_status")]
        public string? ScanStatus { get; set; } // PS_STATUS

        [JsonProperty("ps_status")]
        public string? Status { get; set; } // PS_STATUS

        [JsonProperty("ps_consignment_note")]
        public string? ConsignmentNote { get; set; } // PS_CONSIGNMENT_NOTE

        [JsonProperty("ps_revenue_center")]
        public string? RevenueCenter { get; set; } // PS_REVENUE_CENTER

        [JsonProperty("ps_consignment_note_confidence")]
        public int? ConsignmentNoteConfidence { get; set; } // PS_CONSIGNMENT_NOTE_CONFIDENCE

        [JsonProperty("ps_ticket_date")]
        public DateTime? TicketDate { get; set; } // PS_TICKET_DATE

        [JsonProperty("ps_ticket_date_confidence")]
        public int? TicketDateConfidence { get; set; } // PS_TICKET_DATE_CONFIDENCE

        [JsonProperty("ps_weighcon_ref")]
        public string? WeighConReference { get; set; } // PS_WEIGHCON_REF

        [JsonProperty("ps_weighcon_ref_confidence")]
        public int? WeighConRefConfidence { get; set; } // PS_WEIGHCON_REF_CONFIDENCE

        [JsonProperty("ps_short_order_ref")]
        public string? ShortOrderNo { get; set; } // PS_SHORT_ORDER_REF

    }
}

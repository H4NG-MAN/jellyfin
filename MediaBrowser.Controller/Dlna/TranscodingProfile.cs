﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace MediaBrowser.Controller.Dlna
{
    public class TranscodingProfile
    {
        [XmlAttribute("container")]
        public string Container { get; set; }

        [XmlAttribute("type")]
        public DlnaProfileType Type { get; set; }

        [XmlAttribute("videoCodec")]
        public string VideoCodec { get; set; }

        [XmlAttribute("audioCodec")]
        public string AudioCodec { get; set; }

        [XmlAttribute("estimateContentLength")]
        public bool EstimateContentLength { get; set; }

        [XmlAttribute("enableMpegtsM2TsMode")]
        public bool EnableMpegtsM2TsMode { get; set; }

        [XmlAttribute("transcodeSeekInfo")]
        public TranscodeSeekInfo TranscodeSeekInfo { get; set; }

        public TranscodingSetting[] Settings { get; set; }

        public TranscodingProfile()
        {
            Settings = new TranscodingSetting[] { };
        }


        public List<string> GetAudioCodecs()
        {
            return (AudioCodec ?? string.Empty).Split(',').Where(i => !string.IsNullOrWhiteSpace(i)).ToList();
        }
    }

    public class TranscodingSetting
    {
        [XmlAttribute("name")]
        public TranscodingSettingType Name { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }

    public enum TranscodingSettingType
    {
        VideoProfile = 0
    }

    public enum TranscodeSeekInfo
    {
        Auto = 0,
        Bytes = 1
    }
}
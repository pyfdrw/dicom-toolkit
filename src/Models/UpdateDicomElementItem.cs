﻿namespace SimpleDICOMToolkit.Models
{
    using Dicom;

    /// <summary>
    /// 更新修改后的DicomElement
    /// </summary>
    public class UpdateDicomElementItem
    {
        public DicomDataset Dataset { get; private set; }

        public DicomVR VR { get; private set; }

        public DicomTag Tag { get; private set; }

        public string[] Values { get; private set; }

        public UpdateDicomElementItem(DicomDataset dataset, DicomVR dicomVR, DicomTag tag, string[] values)
        {
            Dataset = dataset;
            VR = dicomVR;
            Tag = tag;
            Values = values;
        }
    }
}

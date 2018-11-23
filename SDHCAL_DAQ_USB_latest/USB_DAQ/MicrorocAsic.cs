﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB_DAQ
{
    class MicrorocAsic
    {
        public MicrorocAsic(int asicNumberInChain, int chainID)
        {
            _asicNumberInChain = asicNumberInChain;
            _chainID = chainID;
        }
        private int _asicNumberInChain;
        private int _chainID;
        public int AsicNumberinChain
        {
            get { return _asicNumberInChain; }
        }
        public int ChainID
        {
            get { return _chainID; }
        }
        private static int HexToInt(string Hex)
        {
            return Convert.ToInt32(Hex, 16);
        }

        /// <summary>
        /// AsicChain ID is the inherent property
        /// </summary>
        /// <param name="usbInterface"></param>
        /// <returns></returns>
        public bool SelectAsicChain(MyCyUsb usbInterface)
        {
            int ChainSelectValue = HexToInt(DifCommandAddress.AsicChainSelectSetAddress) + ChainID;
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ChainSelectValue));
        }

        /// <summary>
        /// ChipID is the start value of the readback data
        /// </summary>
        /// <param name="ChipID">ASIC Header</param>
        /// <param name="usbInterface"></param>
        /// <param name="IllegalInput">True for error</param>
        /// <returns></returns>
        public bool SetChipID(string ChipID, int Offset, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.Check8BitHexLegal(ChipID))
            {
                IllegalInput = false;
                int ChipIDValue = HexToInt(ChipID) + Offset;
                int ChipIDValue1 = (byte)(ChipIDValue & 15) + HexToInt(DifCommandAddress.ChipID3to0Address);
                int ChipIDValue2 = (byte)((ChipIDValue >> 4) & 15) + HexToInt(DifCommandAddress.ChipID7to4Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ChipIDValue1));
                if (!bResult)
                {
                    return false;
                }
                else
                {
                    return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ChipIDValue2));
                }
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SlowControlOrReadScope"></param>
        /// <param name="usbInterface"></param>
        /// <returns></returns>
        public static bool SlowControlOrReadScopeSelect(int SlowControlOrReadScope, MyCyUsb usbInterface)
        {
            int CommandValue = SlowControlOrReadScope + HexToInt(DifCommandAddress.SlowControlOrReadScopeSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(CommandValue));
        }

        public bool DataoutChannelSelect(int DataoutChannel, MyCyUsb usbInterface)
        {
            int DataoutChannelValue = DataoutChannel + HexToInt(DifCommandAddress.DataoutChannelSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DataoutChannelValue));
        }

        public bool TransmitOnChannelSelect(int TransmitOnChannel, MyCyUsb usbInterface)
        {
            int TransmitOnChannelValue = TransmitOnChannel + HexToInt(DifCommandAddress.TransmitOnChannelSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TransmitOnChannelValue));
        }

        public bool StartReadoutChannelSelect(int StartReadoutChannel, MyCyUsb usbInterface)
        {
            int StartReadoutChannelValue = StartReadoutChannel + HexToInt(DifCommandAddress.StartReadoutChannelSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(StartReadoutChannelValue));
        }

        public bool EndReadoutChannelSelect(int EndReadoutChannel, MyCyUsb usbInterface)
        {
            int EndReadoutChannelValue = EndReadoutChannel + HexToInt(DifCommandAddress.EndReadoutChannelSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(EndReadoutChannelValue));
        }

        public static bool InternalRazSignalLengthSelect(int InternalRazSignalLength, MyCyUsb usbInterface)
        {
            int InternalRazSignalLengthValue = InternalRazSignalLength + HexToInt(DifCommandAddress.InternalRazSignalLengthAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(InternalRazSignalLengthValue));
        }

        public bool CkMuxSet(int CkMux, MyCyUsb usbInterface)
        {
            int CkMuxValue = CkMux + HexToInt(DifCommandAddress.CkMuxAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(CkMuxValue));
        }

        public static bool ExternalRazOrInternalRazSelect(int ExternalRazOrInternalRaz, MyCyUsb usbInterface)
        {
            int ExternalRazEnableValue = ExternalRazOrInternalRaz + HexToInt(DifCommandAddress.ExternalRazSignalEnableAddress);
            int InternalRazEnableValue = ExternalRazOrInternalRaz + HexToInt(DifCommandAddress.InternalRazSignalEnableAddress) + 1;
            bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ExternalRazEnableValue));
            if (bResult)
            {
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(InternalRazEnableValue));
            }
            else
            {
                return false;
            }
        }

        public bool ExternalTriggerEnableSet(int ExternalTriggerEnable, MyCyUsb usbInterface)
        {
            int ExternalTriggerEnableValue = ExternalTriggerEnable + HexToInt(DifCommandAddress.ExternalTriggerEnableAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ExternalTriggerEnableValue));
        }

        public static bool TriggerNor64OrDirectOutputSelect(int TriggerNor64OrDirectOutput, MyCyUsb usbInterface)
        {
            int TriggerNor64OrDirectOutputValue = TriggerNor64OrDirectOutput + HexToInt(DifCommandAddress.TriggerNor64OrDirectSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerNor64OrDirectOutputValue));
        }

        public static bool TriggerOutputEnableSet(int TriggerOutputEnable, MyCyUsb usbInterface)
        {
            int TriggerOutputEnableValue = TriggerOutputEnable + HexToInt(DifCommandAddress.TriggerOutputEnableAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerOutputEnableValue));
        }

        public bool TriggerToWriteRamSelect(int TriggerToWriteRam, MyCyUsb usbInterface)
        {
            int TriggerToWriteRamValue = TriggerToWriteRam + HexToInt(DifCommandAddress.TriggerToWriteSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerToWriteRamValue));
        }

        public bool DacEnableSet(int DacEnable, MyCyUsb usbInterface)
        {
            int DacEnableValue = DacEnable + HexToInt(DifCommandAddress.DacEnableAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacEnableValue));
        }

        public bool BandGapEnableSet(int BandGapEnable, MyCyUsb usbInterface)
        {
            int BandGapEnableValue = BandGapEnable + HexToInt(DifCommandAddress.BandGapEnableAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(BandGapEnable));
        }

        public bool MaskChannelSet(string MaskChannel, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(MaskChannel) && int.Parse(MaskChannel) <= 64)
            {
                IllegalInput = false;
                int MaskChannelValue = int.Parse(MaskChannel) - 1;
                int MaskChannelValue1 = (byte)(MaskChannelValue & 15) + HexToInt(DifCommandAddress.MaskChannel3to0Address);
                int MaskChannelValue2 = (byte)((MaskChannelValue >> 4) & 15) + HexToInt(DifCommandAddress.MaskChannel5to4Address);
                if (usbInterface.CommandSend(usbInterface.ConstCommandByteArray(MaskChannelValue1)))
                {
                    return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(MaskChannelValue2));
                }
                else
                {
                    return false;
                }
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public bool DiscriminatorMaskSet(int MaskDiscriminator, MyCyUsb usbInterface)
        {
            int MaskDiscriminatorValue = MaskDiscriminator + HexToInt(DifCommandAddress.DiscriMaskAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(MaskDiscriminatorValue));
        }

        public bool MaskModeSet(int MaskMode, MyCyUsb usbInterface)
        {
            int MaskModeValue = MaskMode + HexToInt(DifCommandAddress.MaskSetAddress) + 1;
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(MaskModeValue));
        }

        public bool LatchedOrDirectOutputSet(int LatchedOrDirectedOutput, MyCyUsb usbInterface)
        {
            int LatchedOrDirectOutputValue = LatchedOrDirectedOutput + HexToInt(DifCommandAddress.LatchedOrDirectOutputAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(LatchedOrDirectOutputValue));
        }

        public bool OTAqEnableSet(int OTAqEnable, MyCyUsb usbInterface)
        {
            int OTAqEnableValue = OTAqEnable + HexToInt(DifCommandAddress.OTAqEnableAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(OTAqEnableValue));
        }

        public bool HighGainShaperFeedbackSelect(int HighGainShaperFeedback, MyCyUsb usbInterface)
        {
            int HighGainShaperFeedbackValue = HighGainShaperFeedback + HexToInt(DifCommandAddress.HighGainShaperFeedbackSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HighGainShaperFeedbackValue));
        }

        public bool ShaperOutLowGainOrHighGainSelect(int ShaperOutLowGainOrHighGain, MyCyUsb usbInterface)
        {
            int ShaperOutLowGainOrHighGainValue = ShaperOutLowGainOrHighGain + HexToInt(DifCommandAddress.ShaperOutLowGainOrHighGainAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ShaperOutLowGainOrHighGainValue));
        }

        public bool LowGainShaperFeedbackSelect(int LowGainShaperFeedback, MyCyUsb usbInterface)
        {
            int LowGainShaperFeedbackValue = LowGainShaperFeedback + HexToInt(DifCommandAddress.LowGainShaperFeedbackSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(LowGainShaperFeedbackValue));
        }

        public bool GainBoostEnableSet(int GainBoostEnable, MyCyUsb usbInterface)
        {
            int GainBoostEnableValue = GainBoostEnable + HexToInt(DifCommandAddress.GainBoostEnableAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(GainBoostEnableValue));
        }

        public bool CTestChannelSet(int CTestChannel, MyCyUsb usbInterface)
        {
            
            int CTestChannelValue1 = (byte)(CTestChannel & 15) + HexToInt(DifCommandAddress.CTestChannel3to0Address);
            int CTestChannelValue2 = (byte)((CTestChannel >> 4) & 15) + HexToInt(DifCommandAddress.CTestChannel7to4Address);
            bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(CTestChannelValue1));
            if (bResult)
            {
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(CTestChannelValue2));
            }
            else
            {
                return false;
            }
        }
        public bool CTestChannelSet(string CTestChannel, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(CTestChannel) && int.Parse(CTestChannel) <= 64)
            {
                IllegalInput = false;
                int CTestChannelValue = int.Parse(CTestChannel);
                return CTestChannelSet(CTestChannelValue, usbInterface);
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public bool ReadScopeChannelSet(string ReadScopeChannel, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(ReadScopeChannel) && int.Parse(ReadScopeChannel) <= 64)
            {
                IllegalInput = false;
                int ReadScopeChannelValue = int.Parse(ReadScopeChannel);
                int ReadScopeChannelValue1 = (byte)(ReadScopeChannelValue & 15) + HexToInt(DifCommandAddress.ReadScopeChannel3to0Address);
                int ReadScopeChannelValue2 = (byte)((ReadScopeChannelValue >> 4) & 15) + HexToInt(DifCommandAddress.ReadScopeChannel7to4Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ReadScopeChannelValue1));
                if (bResult)
                {
                    return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ReadScopeChannelValue2));
                }
                else
                {
                    return false;
                }
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        /// <summary>
        /// All Asic should be set with the same value
        /// </summary>
        /// <param name="PowerPulsingEnable"></param>
        /// <param name="usbInterface"></param>
        /// <returns></returns>
        public static bool SlowControlParameterPowerPulsingEnable(int PowerPulsingEnable, MyCyUsb usbInterface)
        {
            int LvdsReceiverPPEnableValue = (PowerPulsingEnable & 1) + HexToInt(DifCommandAddress.LvdsReceiverPPEnableAddress);
            int DacPPEnableValue = ((PowerPulsingEnable & 2) >> 1) + HexToInt(DifCommandAddress.DacPPEnableAddress);
            int BandGapPPEnableValue = ((PowerPulsingEnable & 4) >> 2) + HexToInt(DifCommandAddress.BandGapPPEnableAddress);
            int DiscriminatorPPEnableValue = ((PowerPulsingEnable & 8) >> 3) + HexToInt(DifCommandAddress.DiscriminatorPPEnableAddress);
            int OTAqPPEnableValue = ((PowerPulsingEnable & 16) >> 4) + HexToInt(DifCommandAddress.OTAqPPEnableAddress);
            int Dac4bitPPEnabelValue = ((PowerPulsingEnable & 32) >> 5) + HexToInt(DifCommandAddress.Dac4bitPPEnableAddress);
            int WidlarPPEnableValue = ((PowerPulsingEnable & 64) >> 6) + HexToInt(DifCommandAddress.WidlarPPEnableAddress);
            int LowGainShaperPPEnableValue = ((PowerPulsingEnable & 128) >> 7) + HexToInt(DifCommandAddress.LowGainShaperPPEnableAddress);
            int HighGainShaperPPEnableValue = ((PowerPulsingEnable & 256) >> 8) + HexToInt(DifCommandAddress.HighGainShaperPPEnableAddress);
            int PreAmplifierPPEnableValue = ((PowerPulsingEnable & 512) >> 9) + HexToInt(DifCommandAddress.PreAmplifierPPEnableAddress);
            #region LVDS Receiver
            bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(LvdsReceiverPPEnableValue));
            if (!bResult)
            {
                return false;
            }
            #endregion
            #region Vth DAC
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacPPEnableValue));
            if (!bResult)
            {
                return false;
            }
            #endregion
            #region Band Gap
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(BandGapPPEnableValue));
            if (!bResult)
            {
                return false;
            }
            #endregion
            #region Discriminator
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DiscriminatorPPEnableValue));
            if (!bResult)
            {
                return false;
            }
            #endregion
            #region OTAq
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(OTAqPPEnableValue));
            if (!bResult)
            {
                return false;
            }
            #endregion
            #region Adjustment DAC
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Dac4bitPPEnabelValue));
            if (!bResult)
            {
                return false;
            }
            #endregion
            #region Widlar
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(WidlarPPEnableValue));
            if (!bResult)
            {
                return false;
            }
            #endregion
            #region High Gain shaper
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(LowGainShaperPPEnableValue));
            if (!bResult)
            {
                return false;
            }
            #endregion
            #region Low Gain shaper
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HighGainShaperPPEnableValue));
            if (!bResult)
            {
                return false;
            }
            #endregion
            #region Pre-amplifier
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(PreAmplifierPPEnableValue));
            #endregion
        }

        public bool ReadoutChannelSelect(int ReadoutChannel, MyCyUsb usbInterface)
        {
            int ReadoutChannelValue = ReadoutChannel + HexToInt(DifCommandAddress.ReadoutChannelSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ReadoutChannelValue));
        }

        public bool AsicNumberSet(int AsicNumber, MyCyUsb usbInterface)
        {
            int AsicNumberValue = AsicNumber + HexToInt(DifCommandAddress.AsicNumberSetAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(AsicNumberValue));
        }

        public bool Dac0VthSet(string Dac0Vth, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(Dac0Vth) && int.Parse(Dac0Vth) < 1024)
            {
                IllegalInput = false;
                int Dac0VthValue = int.Parse(Dac0Vth);
                int Dac0VthValue1 = (byte)(Dac0VthValue & 15) + HexToInt(DifCommandAddress.Dac0Vth3to0Address);
                int Dac0VthValue2 = (byte)((Dac0VthValue >> 4) & 15) + HexToInt(DifCommandAddress.Dac0Vth7to4Address);
                int Dac0VthValue3 = (byte)((Dac0VthValue >> 8) & 3) + HexToInt(DifCommandAddress.Dac0Vth9to8Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Dac0VthValue1));
                if (!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Dac0VthValue2));
                if (!bResult)
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Dac0VthValue3));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public bool Dac1VthSet(string Dac1Vth, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(Dac1Vth) && int.Parse(Dac1Vth) < 1024)
            {
                IllegalInput = false;
                int Dac1VthValue = int.Parse(Dac1Vth);
                int Dac1VthValue1 = (byte)(Dac1VthValue & 15) + HexToInt(DifCommandAddress.Dac1Vth3to0Address);
                int Dac1VthValue2 = (byte)((Dac1VthValue >> 4) & 15) + HexToInt(DifCommandAddress.Dac1Vth7to4Address);
                int Dac1VthValue3 = (byte)((Dac1VthValue >> 8) & 3) + HexToInt(DifCommandAddress.Dac1Vth9to8Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Dac1VthValue1));
                if (!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Dac1VthValue2));
                if (!bResult)
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Dac1VthValue3));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public bool Dac2VthSet(string Dac2Vth, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(Dac2Vth) && int.Parse(Dac2Vth) < 1024)
            {
                IllegalInput = false;
                int Dac2VthValue = int.Parse(Dac2Vth);
                int Dac2VthValue1 = (byte)(Dac2VthValue & 15) + HexToInt(DifCommandAddress.Dac2Vth3to0Address);
                int Dac2VthValue2 = (byte)((Dac2VthValue >> 4) & 15) + HexToInt(DifCommandAddress.Dac2Vth7to4Address);
                int Dac2VthValue3 = (byte)((Dac2VthValue >> 8) & 3) + HexToInt(DifCommandAddress.Dac2Vth9to8Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Dac2VthValue1));
                if (!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Dac2VthValue2));
                if (!bResult)
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Dac2VthValue3));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public bool ParameterLoadStart(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.ParameterLoadStartAddress) + 1));
        }

        public static bool ExternalRazModeSelect(int ExternalRazMode, MyCyUsb usbInterface)
        {
            int ExternalRazModeValue = ExternalRazMode + HexToInt(DifCommandAddress.ExternalRazModeSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ExternalRazModeValue));
        }

        public static bool ExternalRazDelayTimeSet(string ExternalRazDelayTime, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(ExternalRazDelayTime) && int.Parse(ExternalRazDelayTime) < 400)
            {
                IllegalInput = false;
                int ExternalRazDelayTimeValue = int.Parse(ExternalRazDelayTime) / 25 + HexToInt(DifCommandAddress.ExternalRazDelayTimeAddress);
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ExternalRazDelayTimeValue));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool PowerPulsingPinEnableSet(int PowerPulsingPinEnable, MyCyUsb usbInterface)
        {
            int PowerPulsingPinEnableValue = PowerPulsingPinEnable + HexToInt(DifCommandAddress.PowerPulsingPinEnableAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(PowerPulsingPinEnableValue));
        }

        public static bool EndReadoutParameterSet(int EndReadoutParameter, MyCyUsb usbInterface)
        {
            int EndReadoutParameterValue = EndReadoutParameter + HexToInt(DifCommandAddress.EndReadoutParameterAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(EndReadoutParameterValue));
        }



        public static bool SCurveTestAsicSelect(int SCurveTestAsic, MyCyUsb usbInterface)
        {
            int SCurveTestAsicValue = SCurveTestAsic + HexToInt(DifCommandAddress.SCurveTestAsicSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(SCurveTestAsicValue));
        }

        public static bool ResetTimeStamp(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.ResetTimeStampAddress) + 1));
        }

        public static bool SweepTestDacSelect(int SweepTestDac, MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.SweepDacSelectAddress) + SweepTestDac));
        }

        public static bool SCurveTestStartDacSet(int StartDac, MyCyUsb usbInterface)
        {
            int StartDacValue1 = (StartDac & 15) + HexToInt(DifCommandAddress.SweepDacStartValue3to0Address);
            int StartDacValue2 = ((StartDac >> 4) & 15) + HexToInt(DifCommandAddress.SweepDacStartValue7to4Address);
            int StartDacValue3 = ((StartDac >> 8) & 3) + HexToInt(DifCommandAddress.SweepDacStartValue9to8Address);
            bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(StartDacValue1));
            if (!bResult)
            {
                return false;
            }
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(StartDacValue2));
            if (!bResult)
            {
                return false;
            }
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(StartDacValue3));
        }
        public static bool SCurveTestStartDacSet(string StartDac, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(StartDac) && int.Parse(StartDac) < 1023)
            {
                IllegalInput = false;
                int StartDacValue = int.Parse(StartDac);
                return SCurveTestStartDacSet(StartDacValue, usbInterface);
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool SCurveTestEndDacSet(int EndDac, MyCyUsb usbInterface)
        {
            int EndDacValue1 = (EndDac & 15) + HexToInt(DifCommandAddress.SweepDacEndValue3to0Address);
            int EndDacValue2 = ((EndDac >> 4) & 15) + HexToInt(DifCommandAddress.SweepDacEndValue7to4Address);
            int EndDacValue3 = ((EndDac >> 8) & 3) + HexToInt(DifCommandAddress.SweepDacEndValue9to8Address);
            bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(EndDacValue1));
            if (!bResult)
            {
                return false;
            }
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(EndDacValue2));
            if (!bResult)
            {
                return false;
            }
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(EndDacValue3));
        }
        public static bool SCurveTestEndDacSet(string EndDac, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(EndDac) && int.Parse(EndDac) < 1024)
            {
                IllegalInput = false;
                int EndDacValue = int.Parse(EndDac);
                return SCurveTestEndDacSet(EndDacValue, usbInterface);
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool SCurveTestDacStepSet(int DacStep, MyCyUsb usbInterface)
        {
            int DacStepValue1 = (DacStep & 15) + HexToInt(DifCommandAddress.SweepDacStepValue3to0Address);
            int DacStepValue2 = ((DacStep >> 4) & 15) + HexToInt(DifCommandAddress.SweepDacStepValue7to4Address);
            int DacStepValue3 = ((DacStep >> 8) & 3) + HexToInt(DifCommandAddress.SweepDacStepValue9to8Address);
            bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacStepValue1));
            if (!bResult)
            {
                return false;
            }
            bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacStepValue2));
            if (!bResult)
            {
                return false;
            }
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacStepValue3));
        }
        public static bool SCurveTestDacStepSet(string DacStep, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(DacStep) && int.Parse(DacStep) < 1023)
            {
                IllegalInput = false;
                int DacStepValue = int.Parse(DacStep);
                return SCurveTestDacStepSet(DacStepValue, usbInterface);
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool RunningModeSelect(int RunningMode, MyCyUsb usbInterface)
        {
            int RunningModeValue = RunningMode + HexToInt(DifCommandAddress.RunningModeSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(RunningModeValue));
        }

        public static bool SCurveTestSingleOr64ChannelSelect(int SingleOr64Channel, MyCyUsb usbInterface)
        {
            int SingleOr64ChannelValue = SingleOr64Channel + HexToInt(DifCommandAddress.SingleOr64ChannelSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(SingleOr64ChannelValue));
        }

        public static bool SCurveTestCTestOrInputSelect(int CTestOrInput, MyCyUsb usbInterface)
        {
            int CTestOrInputValue = CTestOrInput + HexToInt(DifCommandAddress.CTestOrInputSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(CTestOrInputValue));
        }

        public static bool SingleTestChannelSet(string SingleTestChannel, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(SingleTestChannel) && int.Parse(SingleTestChannel) < 64)
            {
                IllegalInput = false;
                int SingleTestChannelValue = int.Parse(SingleTestChannel);
                int SingleTestChannelValue1 = (byte)(SingleTestChannelValue & 15) + HexToInt(DifCommandAddress.SingleTestChannelSet3to0Address);
                int SingleTestChannelValue2 = (byte)((SingleTestChannelValue >> 4) & 3) + HexToInt(DifCommandAddress.SingleTestChannelSet5to4Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(SingleTestChannelValue1));
                if (bResult)
                {
                    return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(SingleTestChannelValue2));
                }
                else
                {
                    return false;
                }
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool SCurveTestTriggerCountMaxSet(string TriggerCountMax, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(TriggerCountMax) && int.Parse(TriggerCountMax) < 65536)
            {
                IllegalInput = false;
                int TriggerCountMaxValue = int.Parse(TriggerCountMax);
                int TriggerCountMaxValue1 = (TriggerCountMaxValue & 15) + HexToInt(DifCommandAddress.TriggerCountMaxSet3to0Address);
                int TriggerCountMaxValue2 = ((TriggerCountMaxValue >> 4) & 15) + HexToInt(DifCommandAddress.TriggerCountMaxSet7to4Address);
                int TriggerCountMaxValue3 = ((TriggerCountMaxValue >> 8) & 15) + HexToInt(DifCommandAddress.TriggerCountMaxSet11to8Address);
                int TriggerCountMaxValue4 = ((TriggerCountMaxValue >> 12) & 15) + HexToInt(DifCommandAddress.TriggerCountMaxSet15to12Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerCountMaxValue1));
                if (!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerCountMaxValue2));
                if (!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerCountMaxValue3));
                if (!bResult)
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerCountMaxValue4));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool SCurveTestTriggerDelaySet(string TriggerDelay, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(TriggerDelay) && int.Parse(TriggerDelay) < 400)
            {
                IllegalInput = false;
                int TriggerDelayValue = int.Parse(TriggerDelay) / 25 + HexToInt(DifCommandAddress.TriggerDelaySetAddress);
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerDelayValue));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool SweepTestStart(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.SweepTestStartStopAddress) + 1));
        }
        public static bool SweepTestStop(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.SweepTestStartStopAddress)));
        }

        public static bool SCurveTestUnmaskAllChannel(int UnmaskAllChannel, MyCyUsb usbInterface)
        {
            int UnmaskAllChannelValue = UnmaskAllChannel + HexToInt(DifCommandAddress.UnmaskAllChannelSetAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(UnmaskAllChannelValue));
        }

        public static bool SCurveTestTriggerOrCountModeSelect(int TriggerOrCountMode, MyCyUsb usbInterface)
        {
            int TriggerOrCountModeValue = TriggerOrCountMode + HexToInt(DifCommandAddress.TriggerEfficiencyOrCountEfficiencySetAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerOrCountModeValue));
        }

        public static bool CounterModeMaxValueSet(string CounterMax, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckDoubleLegal(CounterMax) && double.Parse(CounterMax) < 65.536)
            {
                IllegalInput = false;
                int CountMaxValue = (int)(double.Parse(CounterMax) * 1000);
                int CountMaxValue1 = (CountMaxValue & 15) + HexToInt(DifCommandAddress.CounterMaxSet3to0Address);
                int CountMaxValue2 = ((CountMaxValue >> 4) & 15) + HexToInt(DifCommandAddress.CounterMaxSet7to4Address);
                int CountMaxValue3 = ((CountMaxValue >> 8) & 15) + HexToInt(DifCommandAddress.CounterMaxSet11to8Address);
                int CountMaxValue4 = ((CountMaxValue >> 12) & 15) + HexToInt(DifCommandAddress.CounterMaxSet15to12Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(CountMaxValue1));
                if (!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(CountMaxValue2));
                if (!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(CountMaxValue3));
                if (!bResult)
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(CountMaxValue4));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool ResetMicrorocAcquisition(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.ResetMicrorocAcqAddress) + 1));
        }

        public static bool ExternalAdcStart(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.ExternalAdcStartStopAddress) + 1));
        }
        public static bool ExternalAdcStop(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.ExternalAdcStartStopAddress)));
        }

        public static bool AdcStartDelayTimeSet(string AdcStartDelayTime, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(AdcStartDelayTime) && int.Parse(AdcStartDelayTime) < 400)
            {
                IllegalInput = false;
                int AdcStartDelayTimeValue = int.Parse(AdcStartDelayTime) / 25 + HexToInt(DifCommandAddress.AdcStartDelayTimeSetAddress);
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(AdcStartDelayTimeValue));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool AdcDataNumberSet(string AdcDataNumber, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if(CheckStringLegal.CheckIntegerLegal(AdcDataNumber) && int.Parse(AdcDataNumber) < 256)
            {
                IllegalInput = false;
                int AdcDataNumberValue = int.Parse(AdcDataNumber);
                int AdcDataNumberValue1 = (AdcDataNumberValue & 15) + HexToInt(DifCommandAddress.AdcDataNumberSet3to0Address);
                int AdcDatanumberValue2 = ((AdcDataNumberValue >> 4) & 15) + HexToInt(DifCommandAddress.AdcDataNumberSet7to4Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(AdcDataNumberValue1));
                if(!bResult)
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(AdcDatanumberValue2));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool TriggerCoincidenceSet(int TriggerCoincidence, MyCyUsb usbInterface)
        {
            int TriggerCoincidenceValue = TriggerCoincidence + HexToInt(DifCommandAddress.TriggerCoincidenceSetAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerCoincidenceValue));
        }

        public static bool HoldDelaySet(string HoldDelay, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if(CheckStringLegal.CheckIntegerLegal(HoldDelay) && int.Parse(HoldDelay) < 2560)
            {
                IllegalInput = false;
                int HoldDelayValue = int.Parse(HoldDelay) / 10;
                int HoldDelayValue1 = (HoldDelayValue & 15) + HexToInt(DifCommandAddress.HoldDelaySet3to0Address);
                int HoldDelayValue2 = ((HoldDelayValue >> 4) & 15) + HexToInt(DifCommandAddress.HoldDelaySet7to4Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HoldDelayValue1));
                if(!bResult)
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HoldDelayValue2));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool HoldTimeSet(string HoldTime, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if(CheckStringLegal.CheckIntegerLegal(HoldTime) && int.Parse(HoldTime) < 1638400)
            {
                IllegalInput = false;
                int HoldTimeValue = int.Parse(HoldTime) / 25;
                int HoldTimeValue1 = (HoldTimeValue & 15) + HexToInt(DifCommandAddress.HoldTimeSet3to0Address);
                int HoldTimeValue2 = ((HoldTimeValue >> 4) & 15) + HexToInt(DifCommandAddress.HoldTimeSet7to4Address);
                int HoldTimeValue3 = ((HoldTimeValue >> 8) & 15) + HexToInt(DifCommandAddress.HoldTimeSet11to8Address);
                int HoldTimeValue4 = ((HoldTimeValue >> 12) & 15) + HexToInt(DifCommandAddress.HoldTimeSet15to12Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HoldTimeValue1));
                if(!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HoldTimeValue2));
                if(!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HoldTimeValue3));
                if(!bResult)
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HoldTimeValue4));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool HoldEnable(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.HoldEnableSetAddress) + 1));
        }
        public static bool HoldDisable(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.HoldEnableSetAddress)));
        }

        public static bool EndHoldTimeSet(string EndHoldTime, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(EndHoldTime) && int.Parse(EndHoldTime) < 1638400)
            {
                IllegalInput = false;
                int EndHoldTimeValue = int.Parse(EndHoldTime) / 25;
                int EndHoldTimeValue1 = (EndHoldTimeValue & 15) + HexToInt(DifCommandAddress.EndHoldTimeSet3to0Address);
                int EndHoldTimeValue2 = ((EndHoldTimeValue >> 4) & 15) + HexToInt(DifCommandAddress.EndHoldTimeSet7to4Address);
                int EndHoldTimeValue3 = ((EndHoldTimeValue >> 8) & 15) + HexToInt(DifCommandAddress.EndHoldTimeSet11to8Address);
                int EndHoldTimeValue4 = ((EndHoldTimeValue >> 12) & 15) + HexToInt(DifCommandAddress.EndHoldTimeSet15to12Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(EndHoldTimeValue1));
                if(!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(EndHoldTimeValue2));
                if(!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(EndHoldTimeValue3));
                if(!bResult)
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(EndHoldTimeValue4));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool LightLed(int Led, MyCyUsb usbInterface)
        {
            int LedValue = Led + HexToInt(DifCommandAddress.LightLedAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(LedValue));
        }

        public static bool MicrorocAcquisitionStart(int StartAsic, MyCyUsb usbInterface)
        {
            int StartValue = StartAsic + HexToInt(DifCommandAddress.AcquisitionStartStopAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(StartValue));
        }
        public static bool MicrorocAcquisitionStop(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.AcquisitionStartStopAddress)));
        }

        public static bool ResetDataFifo(MyCyUsb usbInterface)
        {
            bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.ResetDataFifoAddress) + 1));
            if(bResult)
            {
                byte[] ClearBytes = new byte[2014];
                bResult = usbInterface.DataRecieve(ClearBytes, ClearBytes.Length);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static bool DaqModeSelect(int DaqMode, MyCyUsb usbInterface)
        {
            int DaqModeValue = DaqMode + HexToInt(DifCommandAddress.DaqSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DaqModeValue));
        }

        public static bool MicrorocStartAcquisitionTimeSet(string StartAcquisitionTime, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if(CheckStringLegal.CheckIntegerLegal(StartAcquisitionTime) && int.Parse(StartAcquisitionTime) < 1638400)
            {
                IllegalInput = false;
                int StartAcquisitionTimeValue = int.Parse(StartAcquisitionTime) / 25;
                int StartAcquisitionTimeValue1 = (StartAcquisitionTimeValue & 15) + HexToInt(DifCommandAddress.MicrorocStartAcquisitionTime3to0Address);
                int StartAcquisitionTimeValue2 = ((StartAcquisitionTimeValue >> 4) & 15) + HexToInt(DifCommandAddress.MicrorocStartAcquisitionTime7to4Address);
                int StartAcquisitionTimeValue3 = ((StartAcquisitionTimeValue >> 8) & 15) + HexToInt(DifCommandAddress.MicrorocStartAcquisitionTime11to8Address);
                int StartAcquisitionTimeValue4 = ((StartAcquisitionTimeValue >> 12) & 15) + HexToInt(DifCommandAddress.MicrorocStartAcquisitionTime15to12Address);
                bool bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(StartAcquisitionTimeValue1));
                if (!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(StartAcquisitionTimeValue2));
                if(!bResult)
                {
                    return false;
                }
                bResult = usbInterface.CommandSend(usbInterface.ConstCommandByteArray(StartAcquisitionTimeValue3));
                if(!bResult)
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(StartAcquisitionTimeValue4));
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool TestSignalColumnSelect(int TestColumn, MyCyUsb usbInterface)
        {
            int TestColumnValue = TestColumn + HexToInt(DifCommandAddress.TestSignalColumnSelectAdress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TestColumnValue));
        }

        public static bool TestSignalRowSelect(int TestRow, MyCyUsb usbInterface)
        {
            int TestRowValue = TestRow + HexToInt(DifCommandAddress.TestSignalRowSelectAdress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TestRowValue));
        }

        public static bool SCurveTestReset(MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(HexToInt(DifCommandAddress.ResetSCurveTestAdress) + 1));
        }

        public static bool AutoDaqChipEnableSet(int Enable, MyCyUsb usbInterface)
        {
            int EnableValue = Enable + HexToInt(DifCommandAddress.ChipFullEnableAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(EnableValue));
        }

        public static bool AutoDaqAcquisitionModeSelect(int AcquisitionMode, MyCyUsb usbInterface)
        {
            int AcquisitionModeValue = AcquisitionMode + HexToInt(DifCommandAddress.AutoDaqAcquisitionModeSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(AcquisitionModeValue));
        }

        public static bool AutoDaqTriggerModeSelect(int TriggerMode, MyCyUsb usbInterface)
        {
            int TriggerModeValue = TriggerMode + HexToInt(DifCommandAddress.AutoDaqTriggerModeSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerModeValue));
        }

        public static bool AutoDaqTriggerDelayTimeSet(string TriggerDelayTime, MyCyUsb usbInterface, out bool IllegealInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(TriggerDelayTime) && (int.Parse(TriggerDelayTime) < 1638400) && (int.Parse(TriggerDelayTime) >= 50))
            {
                IllegealInput = false;
                int TriggerDelayValue = (int.Parse(TriggerDelayTime) - 50) / 25;
                int TriggerDelayValue1 = (TriggerDelayValue & 15) + HexToInt(DifCommandAddress.AutoDaqTriggerDelayTime3to0Address);
                int TriggerDelayValue2 = ((TriggerDelayValue >> 4) & 15) + HexToInt(DifCommandAddress.AutoDaqTriggerDelayTime7to4Address);
                int TriggerDelayValue3 = ((TriggerDelayValue >> 8) & 15) + HexToInt(DifCommandAddress.AutoDaqTriggerDelayTime11to8Address);
                int TriggerDelayValue4 = ((TriggerDelayValue >> 12) & 15) + HexToInt(DifCommandAddress.AutoDaqTriggerDelayTime15to12Address);
                if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerDelayValue1)))
                {
                    return false;
                }
                if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerDelayValue2)))
                {
                    return false;
                }
                if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerDelayValue3)))
                {
                    return false;
                }
                return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(TriggerDelayValue4));
            }
            else
            {
                IllegealInput = true;
                return false;
            }
        }

        public static bool SCurveTestSynchronousClockSelect(int SyncClockSelect, MyCyUsb usbInterface)
        {
            int SyncClockSelectValue = SyncClockSelect + HexToInt(DifCommandAddress.SCurveTestInnerClockEnableAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(SyncClockSelectValue));
        }

        public static bool InternalSynchronousClockPeriodSelect(int ClockPeriod, MyCyUsb usbInterface)
        {
            int ClockPeriodValue1 = (ClockPeriod & 15) + HexToInt(DifCommandAddress.InternalSynchronousClockPeriod3to0Address);
            int ClockPeriodValue2 = ((ClockPeriod >> 4) & 15) + HexToInt(DifCommandAddress.InternalSynchronousClockPeriod7to4Address);
            int ClockPeriodValue3 = ((ClockPeriod >> 8) & 15) + HexToInt(DifCommandAddress.InternalSynchronousClockPeriod11to8Address);
            int ClockPeriodValue4 = ((ClockPeriod >> 12) & 15) + HexToInt(DifCommandAddress.InternalSynchronousClockPeriod15to12Address);
            if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ClockPeriodValue1)))
            {
                return false;
            }
            if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ClockPeriodValue2)))
            {
                return false;
            }
            if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ClockPeriodValue3)))
            {
                return false;
            }
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(ClockPeriodValue4));
        }
        public static bool InternalSynchronousClockPeriodSelect(string ClockPeriod, MyCyUsb usbInterface, out bool IllegealInput)
        {
            if(CheckStringLegal.CheckIntegerLegal(ClockPeriod) && int.Parse(ClockPeriod) < 1638400)
            {
                IllegealInput = false;
                return InternalSynchronousClockPeriodSelect(int.Parse(ClockPeriod) / 25, usbInterface);
            }
            else
            {
                IllegealInput = true;
                return false;
            }
        }

        public static bool AutoCalibrationDacPowerDownSet(int PowerDown, MyCyUsb usbInterface)
        {
            int PowerDownValue = PowerDown + HexToInt(DifCommandAddress.AutoCalibrationDacPowerDownAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(PowerDownValue));
        }
        public static bool AutoCalibrationDacSpeedSet(int Speed, MyCyUsb usbInterface)
        {
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(Speed + HexToInt(DifCommandAddress.AutoCalibrationDacSpeedAddress)));
        }

        public static bool AutoCalibrationDac1DataSet(int Dac, MyCyUsb usbInterface)
        {
            int DacValue1 = (Dac & 15) + HexToInt(DifCommandAddress.AutoCalibrationDac1Data3to0Address);
            int DacValue2 = ((Dac >> 4) & 15) + HexToInt(DifCommandAddress.AutoCalibrationDac1Data7to4Address);
            int DacValue3 = ((Dac >> 8) & 15) + HexToInt(DifCommandAddress.AutoCalibrationDac1Data11to8Address);
            if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacValue1)))
            {
                return false;
            }
            if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacValue2)))
            {
                return false;
            }
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacValue3));
        }
        public static bool AutoCalibrationDac1DataSet(string Dac, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if(CheckStringLegal.CheckIntegerLegal(Dac) && (int.Parse(Dac) < 4096))
            {
                IllegalInput = false;
                return AutoCalibrationDac1DataSet(int.Parse(Dac), usbInterface);
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool AutoCalibrationDac2DataSet(int Dac, MyCyUsb usbInterface)
        {
            int DacValue1 = (Dac & 15) + HexToInt(DifCommandAddress.AutoCalibrationDac2Data3to0Address);
            int DacValue2 = ((Dac >> 4) & 15) + HexToInt(DifCommandAddress.AutoCalibrationDac2Data7to4Address);
            int DacValue3 = ((Dac >> 8) & 15) + HexToInt(DifCommandAddress.AutoCalibrationDac2Data11to8Address);
            if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacValue1)))
            {
                return false;
            }
            if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacValue2)))
            {
                return false;
            }
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacValue3));
        }
        public static bool AutoCalibrationDac2DataSet(string Dac, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if (CheckStringLegal.CheckIntegerLegal(Dac) && (int.Parse(Dac) < 4096))
            {
                IllegalInput = false;
                return AutoCalibrationDac2DataSet(int.Parse(Dac), usbInterface);
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool AutoCalibrationDacSelect(int DacSelect, MyCyUsb usbInterface)
        {
            int DacSelectValue = DacSelect + HexToInt(DifCommandAddress.AutoCalibrationDacLoadSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(DacSelectValue));
        }

        public static bool AutoCalibrationDacLoad(MyCyUsb usbInterface)
        {
            int LoadValue = HexToInt(DifCommandAddress.AutoCalibrationDacLoadStartAddress) + 1;
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(LoadValue));
        }

        public static bool AutoCalibrationSwitcherOnTimeSet(int SwitcherOnTime, MyCyUsb usbInterface)
        {
            int SwitcherOnTimeValue1 = (SwitcherOnTime & 15) + HexToInt(DifCommandAddress.AutoCalibrationSwitcherOnTime3to0Address);
            int SwitcherOnTimeValue2 = ((SwitcherOnTime >> 4) & 15) + HexToInt(DifCommandAddress.AutoCalibrationSwitcherOnTime7to4Address);
            int SwitcherOnTimeValue3 = ((SwitcherOnTime >> 8) & 15) + HexToInt(DifCommandAddress.AutoCalibrationSwitcherOnTime11to8Address);
            int SwitcherOnTimeValue4 = ((SwitcherOnTime >> 12) & 15) + HexToInt(DifCommandAddress.AutoCalibrationSwitcherOnTime15to12Address);
            if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(SwitcherOnTimeValue1)))
            {
                return false;
            }
            if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(SwitcherOnTimeValue2)))
            {
                return false;
            }
            if (!usbInterface.CommandSend(usbInterface.ConstCommandByteArray(SwitcherOnTimeValue3)))
            {
                return false;
            }
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(SwitcherOnTimeValue4));
        }
        public static bool AutoCalibrationSwitcherOnTimeSet(string SwitcherOnTime, MyCyUsb usbInterface, out bool IllegalInput)
        {
            if(CheckStringLegal.CheckIntegerLegal(SwitcherOnTime) && (int.Parse(SwitcherOnTime) < 1638400))
            {
                IllegalInput = false;
                return AutoCalibrationSwitcherOnTimeSet(int.Parse(SwitcherOnTime) / 25, usbInterface);
            }
            else
            {
                IllegalInput = true;
                return false;
            }
        }

        public static bool AutoCalibrationSwitcherSelect(int Switcher, MyCyUsb usbInterface)
        {
            int SwitcherValue = Switcher + HexToInt(DifCommandAddress.AutoCalibrationSwitcherSelectAddress);
            return usbInterface.CommandSend(usbInterface.ConstCommandByteArray(SwitcherValue));
        }

        public bool SetChannelCalibration(MyCyUsb usbInterface, params byte[] CalibrationData)
        {
            byte[] ChannelCaliCommandHeader = GenerateCaliCommandHeader();
            byte CaliByte1, CaliByte2;
            byte[] CommandBytes = new byte[2];
            bool bResult;
            for (int j = 0; j < 64; j++)
            {
                CaliByte1 = (byte)((ChannelCaliCommandHeader[j] >> 4) + 0xC0);
                CaliByte2 = (byte)((ChannelCaliCommandHeader[j] << 4) + CalibrationData[j]);
                CommandBytes = usbInterface.ConstCommandByteArray(CaliByte1, CaliByte2);
                bResult = usbInterface.CommandSend(CommandBytes);
                if (!bResult)
                {
                    return false;
                }
            }
            return true;
        }
        private byte[] GenerateCaliCommandHeader()
        {
            string[] Chn = new string[64];
            byte[] ChannelCaliCommandHeader = new byte[64];
            for (int i = 0; i < 64; i++)
            {
                Chn[i] = string.Format("Chn{0}", i);
                ChannelCaliCommandHeader[i] = (byte)(0xC0 + i);
            }
            return ChannelCaliCommandHeader;
        }

    }
}


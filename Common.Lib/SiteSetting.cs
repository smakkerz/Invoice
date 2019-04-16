using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;

namespace Common.Lib
{
    public class SiteSetting
    {
        public static string Rewards_ClientId
        {
            get
            {
                return ConfigurationManager.AppSettings["Rewards_ClientId"];
            }
        }
        public static string Rewards_ClientSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["Rewards_ClientSecret"];
            }
        }
        public static string Rewards_WishListEndPoint
        {
            get
            {
                return ConfigurationManager.AppSettings["Rewards_WishListEndPoint"];
            }
        }
        public static int Rewards_WishListTreshold
        {
            get
            {
                int result = 0;
                string tresholdString = ConfigurationManager.AppSettings["Rewards_WishListTreshold"];
                if (string.IsNullOrEmpty(tresholdString)) return result;
                if (int.TryParse(tresholdString, out result))
                {
                    return result;
                }
                return result;
            }
        }
        public static string BebelacImageURL
        {
            get
            {
                return ConfigurationManager.AppSettings["BebelacImageURL"];
            }
        }
        public static bool IsMemberVoucherEnabled
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["IsMemberVoucherEnabled"]);
            }
        }
        public static int NewMemberVoucherType
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["NewMemberVoucherType"]);
            }
        }
        
        public static string NewMemberVoucherTemplate = "NewMemberVoucherTemplate";

        public static DateTime? OldMemberParameterDate
        {
            get
            {
                var dateTimeStr = ConfigurationManager.AppSettings["OldMemberParameterDate"];
                if (string.IsNullOrEmpty(dateTimeStr)) return null;
                DateTime dateTimeParsed;
                if (!DateTime.TryParseExact(dateTimeStr, "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTimeParsed))
                {
                    return null;
                }
                return dateTimeParsed;
            }
        }
        public static string PathLogERRORCsv
        {
            get
            {
                return ConfigurationManager.AppSettings["PathLogERRORCsv"];
            }
        }
        public static string NutriclubSpecialRegisterEvent
        {
            get
            {
                return ConfigurationManager.AppSettings["NutriclubSpecialRegisterEvent"];
            }
        }

        public static Dictionary<int, string> ReceiptRejectReasonList
        {
            get
            {
                return new Dictionary<int, string>() {
                    { 0, "Struk Tidak terbaca dengan Jelas" },
                    { 1, "Struk terpotong (Tidak ada Tgl/Jam Transaksi/No Struk/nama Toko)" },
                    { 2, "Toko Belum terdaftar" },
                    { 3, "Sudah mencapai Max Limit perbulan" },
                    { 4, "Struk sudah pernah diupload" },
                    { 5, "Tgl Transaksi diluar periode Program" },
                    { 6, "Produk tidak ikut serta dalam program Rewards" },
                    { 7, "Format Struk tidak sesuai dengan format resmi dari Toko terlampir" },
                    { 8, "Foto yang di upload bukan berupa Bukti Pembayaran" },
                    { 9, "Struk Dupikat, Copy & Reprint tidak bisa diproses" },
                    { 10, "Tgl Transaksi struk sudah lebih > 3 bulan" },
                    { 11, "Tidak melampirkan struk, silahkan upload ulang" },
                    { 12, "Tanggal Transaksi Struk/Receipt Sudah Lebih dari Satu Bulan" },
                    { 13, "Struk sudah diproses melalui JD.ID" },
                    { 14, "Struk Sudah Diproses Melalui Alfamidi Ponta" },
                    { 15, "1 Kali Upload Hanya Untuk 1 StruK" }
                };
            }
        }

        #region ChildAgeBelow1YearRule
        public static string ChildAgeBelow1YearRuleValidationMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["ChildAgeBelow1YearRuleValidationMessage"];
            }
        }

        public static string[] ChildAgeBelow1YearRuleAllowedActionList
        {
            get
            {
                var value = ConfigurationManager.AppSettings["ChildAgeBelow1YearRuleAllowedActionList"];
                if (string.IsNullOrEmpty(value))
                    return new string[] { };
                return value.Split(',');
            }
        }

        public static string BlankChildBirthDateRuleValidationMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["BlankChildBirthDateRuleValidationMessage"];
            }
        }

        public static string InPregnancyPeriodRuleValidationMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["InPregnancyPeriodRuleValidationMessage"];
            }
        }

        public static string ChildDateValidationSuccessRuleValidationMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["ChildDateValidationSuccessRuleValidationMessage"];
            }
        }
        #endregion

        #region Integrasi ALFA MIDI
        //ADD By Bryant for Alfa integration Needed 20170505
        #region Bebe
        //Bebe Region
        public static string FileNameGetCSVBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["FileNameGetCSVBebe"];
            }
        }
        public static int AlfaRetailIdBebe
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["AlfaRetailIdBebe"]);
            }
        }
        public static int AlfaMidiRetailIdBebe
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["AlfaMidiRetailIdBebe"]);
            }
        }
        public static string FileNamePutCSVBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["FileNamePutCSVBebe"];
            }
        }
        public static string PathDirSendBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["PathDirSendBebe"];
            }
        }

        public static string FtpDirSendBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["FtpDirSendBebe"];
            }
        }
        public static string DirWinscpBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["DirWinscpBebe"];
            }
        }
        public static string FtpSessionNameBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["FtpSessionNameBebe"];
            }
        }

        public static string PathDirGetBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["PathDirGetBebe"];
            }
        }
        public static string FtpDirGetBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["FtpDirGetBebe"];
            }
        }
        public static string FileSalesGetCSVBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["FileSalesGetCSVBebe"];
            }
        }
        public static string telcomnetAPIURLBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["telcomnetAPIURLBebe"];
            }
        }
        public static string CidAlfaBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["CidAlfaBebe"];
            }
        }
        public static string msgKePontaBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["msgKePontaBebe"];
            }
        }
        public static string msgKeBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["msgKeBebe"];
            }
        }

        public static string msgToPontaBebe
        {
            get
            {
                return ConfigurationManager.AppSettings["msgToPontaBebe"];
            }
        }
        public static string msgToBB
        {
            get
            {
                return ConfigurationManager.AppSettings["msgToBB"];
            }
        }
        #endregion

        #region MobileLogin Scheduler Configurations
        public static string MobileLoginCSVPath
        {
            get
            {
                return ConfigurationManager.AppSettings["MobileLoginCSVPath"];
            }
        }

        public static string MobileLoginCSVFileNameFormat
        {
            get
            {
                return ConfigurationManager.AppSettings["MobileLoginCSVFileNameFormat"];
            }
        }

        public static string MobileLoginFtpDirRemote
        {
            get
            {
                return ConfigurationManager.AppSettings["MobileLoginFtpDirRemote"];
            }
        }

        public static string MobileLoginFtpAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["MobileLoginFtpAddress"];
            }
        }

        public static string MobileLoginFtpUser
        {
            get
            {
                return ConfigurationManager.AppSettings["MobileLoginFtpUser"];
            }
        }

        public static string MobileLoginFtpPass
        {
            get
            {
                return ConfigurationManager.AppSettings["MobileLoginFtpPass"];
            }
        }

        public static string MobileLoginFtpSessionName
        {
            get
            {
                return ConfigurationManager.AppSettings["MobileLoginFtpSessionName"];
            }
        }

        public static string MobileLoginLogPath
        {
            get
            {
                return ConfigurationManager.AppSettings["MobileLoginLogPath"];
            }
        }
        #endregion

        #region Nutri
        //Bebe Region
        public static string FileNameGetCSVNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["FileNameGetCSVNutri"];
            }
        }
        public static int AlfaRetailIdNutri
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["AlfaRetailIdNutri"]);
            }
        }
        public static int AlfaMidiRetailIdNutri
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["AlfaMidiRetailIdNutri"]);
            }
        }
        public static string FileNamePutCSVNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["FileNamePutCSVNutri"];
            }
        }
        public static string PathDirSendNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["PathDirSendNutri"];
            }
        }

        public static string FtpDirSendNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["FtpDirSendNutri"];
            }
        }
        public static string DirWinscpNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["DirWinscpNutri"];
            }
        }
        public static string FtpSessionNameNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["FtpSessionNameNutri"];
            }
        }
        public static string PathDirGetNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["PathDirGetNutri"];
            }
        }
        public static string FtpDirGetNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["FtpDirGetNutri"];
            }
        }
        public static string FileSalesGetCSVNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["FileSalesGetCSVNutri"];
            }
        }
        public static string telcomnetAPIURLNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["telcomnetAPIURLNutri"];
            }
        }
        public static string CidAlfaNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["CidAlfaNutri"];
            }
        }
        public static string msgKePontaNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["msgKePontaNutri"];
            }
        }
        public static string msgKeNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["msgKeNutri"];
            }
        }

        public static string msgToPontaNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["msgToPontaNutri"];
            }
        }
        public static string msgToNutri
        {
            get
            {
                return ConfigurationManager.AppSettings["msgToNutri"];
            }
        }
        #endregion


        #region ALFA PROPERTIES
        public static string FileNameGetCSV
        {
            get
            {
                return ConfigurationManager.AppSettings["FileNameGetCSV"];
            }
        }
        public static string FileNamePutCSV
        {
            get
            {
                return ConfigurationManager.AppSettings["FileNamePutCSV"];
            }
        }
        public static string PathDirSend
        {
            get
            {
                return ConfigurationManager.AppSettings["PathDirSend"];
            }
        }

        public static string FtpDirSend
        {
            get
            {
                return ConfigurationManager.AppSettings["FtpDirSend"];
            }
        }
        public static string DirWinscp
        {
            get
            {
                return ConfigurationManager.AppSettings["DirWinscp"];
            }
        }
        public static string FtpSessionName
        {
            get
            {
                return ConfigurationManager.AppSettings["FtpSessionName"];
            }
        }
        public static string PathDirGet
        {
            get
            {
                return ConfigurationManager.AppSettings["PathDirGet"];
            }
        }
        public static string FtpDirGet
        {
            get
            {
                return ConfigurationManager.AppSettings["FtpDirGet"];
            }
        }
        public static string FileSalesGetCSV
        {
            get
            {
                return ConfigurationManager.AppSettings["FileSalesGetCSV"];
            }
        }
        public static string telcomnetAPIURL
        {
            get
            {
                return ConfigurationManager.AppSettings["telcomnetAPIURL"];
            }
        }
        public static string CidAlfa
        {
            get
            {
                return ConfigurationManager.AppSettings["CidAlfa"];
            }
        }
        public static string msgKePonta
        {
            get
            {
                return ConfigurationManager.AppSettings["msgKePonta"];
            }
        }


        public static string msgToPonta
        {
            get
            {
                return ConfigurationManager.AppSettings["msgToPonta"];
            }
        }
        public static int AlfaRetailId
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["AlfaRetailId"]);
            }
        }
        #endregion

        #endregion

        #region MobilePushNotification
        public static string IOSKey
        {
            get
            {
                return ConfigurationManager.AppSettings["IOSKey"];
            }
        }
        public static string IOSPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["IOSPassword"];
            }
        }
        public static string GoogleCloudMessagingKey
        {
            get
            {
                return ConfigurationManager.AppSettings["GoogleCloudMessagingKey"];
            }
        }
        #endregion

        #region Careline
        public static string CareLineNumber
        {
            get
            {
                return ConfigurationManager.AppSettings["CareLineNumber"];
            }
        }

        #endregion

        #region ElasticSearch
        public static string ElasticServerUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ElasticServerUrl"];
            }
        }

        public static string ElasticServerAuthUser
        {
            get
            {
                return ConfigurationManager.AppSettings["ElasticServerAuthUser"];
            }
        }

        public static string ElasticServerAuthPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["ElasticServerAuthPassword"];
            }
        }

        public static string ElasticServerDefaultIndex
        {
            get
            {
                return ConfigurationManager.AppSettings["ElasticServerDefaultIndex"];
            }
        }
        #endregion

        public static string SuccessRegisterSmsText
        {
            get
            {
                return ConfigurationManager.AppSettings["SuccessRegisterSmsText"];
            }
        }
        public static string TelcomMateCId
        {
            get
            {
                return ConfigurationManager.AppSettings["TelcomMateCId"];
            }
        }
        public static string TelcomMateCToken
        {
            get
            {
                return ConfigurationManager.AppSettings["TelcomMateCToken"];
            }
        }
        public static string MsgResponseFormatPromoIscheckTrue
        {
            get
            {
                return ConfigurationManager.AppSettings["MsgResponseFailedFormatPromoIscheckTrue"];

            }
        }

        public static string NutriPointUpdateProfile
        {
            get
            {
                return ConfigurationManager.AppSettings["NutriPointUpdateProfile"];
            }
        }


        public static string TripleDesKey
        {
            get
            {
                return ConfigurationManager.AppSettings["TripleDesKey"];
            }
        }

        public static string BitlyUser
        {
            get
            {
                return ConfigurationManager.AppSettings["BitlyUser"];
            }
        }

        public static string BitlyApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["BitlyApiKey"];
            }
        }

        public static string ForgotPasswordSmsText
        {
            get
            {
                return ConfigurationManager.AppSettings["ForgotPasswordSmsText"];
            }
        }

        public static int ForgotPasswordLinkExpiredInHour
        {
            get
            {
                int result = 5;
                string tresholdString = ConfigurationManager.AppSettings["ForgotPasswordLinkExpiredInHour"];
                if (string.IsNullOrEmpty(tresholdString)) return result;
                if (int.TryParse(tresholdString, out result))
                {
                    return result;
                }
                return result;
            }
        }

        public static string VerifyForgotPaswordURL
        {
            get
            {
                return ConfigurationManager.AppSettings["VerifyForgotPaswordURL"];
            }
        }

        public static string EmailForgotPasswordTemplateURL
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailForgotPasswordTemplateURL"];
            }
        }

        public static string EmailForgotPasswordSubjectEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailForgotPasswordSubjectEmail"];
            }
        }

        public static string TransferPointFee
        {
            get
            {
                return ConfigurationManager.AppSettings["TransferPointFee"];
            }
        }

        public static string ReceiptExpiredValidationMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["ReceiptExpiredValidationMessage"];
            }
        }
    }
}

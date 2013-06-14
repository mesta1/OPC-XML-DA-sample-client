using OpcXmlDaClient.WebReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace OpcXmlDaClient
{
    class OpcXmlDaDriver
    {
        public OpcXmlDaDriver()
        {
            RequestOptions ReadOptions = new RequestOptions();
            ReadOptions.ClientRequestHandle = "";
            ReadOptions.LocaleID = "DE-AT";
            ReadOptions.RequestDeadlineSpecified = true;
            ReadOptions.ReturnDiagnosticInfo = true;
            ReadOptions.ReturnErrorText = true;
            ReadOptions.ReturnItemName = true;
            ReadOptions.ReturnItemPath = true;
            ReadOptions.ReturnItemTime = true;

            ReadRequestItemList ReadItemList = new
            ReadRequestItemList();
            ReadRequestItem[] ReadItemArray = new
            ReadRequestItem[1];
            ReadRequestItem ReadItem = new ReadRequestItem();
            ReadItem.ItemPath = "SIMOTION";
            ReadItem.ItemName = "var/userData.user5";
            ReadItemArray[0] = ReadItem;
            ReadItemList.Items = ReadItemArray;
            ReplyItemList ReadReplyList;
            OPCError[] ReadErrorList;

            Service C230_2_Server = new Service();
            C230_2_Server.Url = "http://169.254.11.22/soap/opcxml";
            System.Net.ICredentials myCredentials = new System.Net.NetworkCredential("simotion", "simotion");
            C230_2_Server.Credentials = myCredentials;
            C230_2_Server.PreAuthenticate = true;
            System.Net.ServicePointManager.Expect100Continue = false;
            C230_2_Server.Read(ReadOptions, ReadItemList, out ReadReplyList, out ReadErrorList);
            //if ((ReadReplyList.Items[0] != null) && (ReadReplyList.Items[0].Value != null) && (ReadReplyList.Items[0].Value.GetType().Name != "XmlNode[]"))
            //    Output.Text = ReadReplyList.Items[0].Value.ToString();
            //else
            //    Output.Text = "<Error>";
            MessageBox.Show(ReadReplyList.Items[0].ItemName.ToString() + "\nValue: " + ReadReplyList.Items[0].Value);
        }
    }
}

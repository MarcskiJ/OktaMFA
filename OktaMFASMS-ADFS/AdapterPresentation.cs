﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityServer.Web.Authentication.External;

namespace OktaMFASMS_ADFS
{
    class AdapterPresentation : IAdapterPresentation, IAdapterPresentationForm
    {
        private string message;
        private bool isPermanentFailure;
        private string upn;
        private string userID;


        public string GetPageTitle(int lcid)
        {
            return "Okta MFA SMS Provider";
        }

        public string GetFormHtml(int lcid)
        {
            string result = "";
            if (!String.IsNullOrEmpty(this.message))
            {
                result += "<p>" + message + "</p>";
            }
            if (!this.isPermanentFailure)
            {
                result += "<form method=\"post\" id=\"loginForm\" autocomplete=\"off\">";
                result += "<p> Enter the SMS code you recieved in the field below, then select Continue </p>";
                result += "PIN: <input id=\"pin\" name=\"pin\" type=\"password\" />";
                result += "<input id=\"context\" type=\"hidden\" name=\"Context\" value=\"%Context%\"/>";
                result += "<input id=\"authMethod\" type=\"hidden\" name=\"AuthMethod\" value=\"%AuthMethod%\"/>";
                result += "<input id=\"continueButton\" type=\"submit\" name=\"Continue\" value=\"Continue\" />";
                result += "<input id=\"upn\" type=\"hidden\" name=\"upn\" value=\"" + this.upn + "\"/>";
                result += "<input id=\"userID\" type=\"hidden\" name=\"userID\" value=\"" + this.userID + "\"/>";
                result += "</form>";
            }
            return result;
        }

        public string GetFormPreRenderHtml(int lcid)
        {
            return string.Empty;
        }
        public AdapterPresentation()
        {
            this.message = string.Empty;
            this.isPermanentFailure = false;
        }
        public AdapterPresentation(string message, bool isPermanentFailure)
        {
            this.message = message;
            this.isPermanentFailure = isPermanentFailure;
        }

        public AdapterPresentation(string upn)
        {
            this.message = string.Empty;
            this.isPermanentFailure = false;
            this.upn = upn;
        }

        public AdapterPresentation(string message, string upn, bool isPermanentFailure, string userID)
        {
            this.message = string.Empty;
            this.isPermanentFailure = false;
            this.upn = upn;
            this.userID = userID;
        }

        public AdapterPresentation(string message, string upn, bool isPermanentFailure)
        {
            this.message = message;
            this.isPermanentFailure = isPermanentFailure;
            this.upn = upn;
        }
    }
}

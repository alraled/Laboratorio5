﻿using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Laboratorio5.WebPart1
{
    [ToolboxItemAttribute(false)]
    public class WebPart1 : WebPart
    {
        protected override void CreateChildControls()
        {
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("Registra los gastos de las facturas");
            SPWeb web = SPContext.Current.Web;
            string keyName = "Total Facturas";

            if (web.Properties[keyName] != null)
            {
                string total = web.Properties[keyName];
                writer.Write("<p>El total de las facturas es: "+total+"</p>");
            }
        }
    }
}

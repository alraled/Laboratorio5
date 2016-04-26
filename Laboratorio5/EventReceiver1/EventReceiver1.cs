using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace Laboratorio5.EventReceiver1
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EventReceiver1 : SPItemEventReceiver
    {
        /// <summary>
        /// An item is being added.
        /// </summary>

        /// <summary>
        /// An item is being updated.
        /// </summary>

        /// <summary>
        /// An item is being deleted.
        /// </summary>


        private void UpdatePropertyBag(SPWeb web, double cambio)
        {
            string keyName = "Total Facturas";
            double actual = 0;
            if (web.Properties[keyName] != null)
            {
                actual = double.Parse(web.Properties[keyName]);
            }

            else
            {
                web.Properties.Add(keyName, "");
            }

            actual += cambio;

            web.Properties[keyName] = actual.ToString();

            web.Properties.Update();
        }

        public override void ItemAdding(SPItemEventProperties properties)
        {
            double valor;
            double.TryParse(properties.AfterProperties["Importe"].ToString(), out valor);
            UpdatePropertyBag(properties.Web, valor);

        }

        public override void ItemUpdating(SPItemEventProperties properties)
        {
            double valorPrevio, nuevoValor;
            double.TryParse(properties.ListItem["Importe"].ToString(), out valorPrevio);
            double.TryParse(properties.AfterProperties["Importe"].ToString(), out nuevoValor);
            double change = valorPrevio - nuevoValor;
            UpdatePropertyBag(properties.Web, change);

        }

        public override void ItemDeleting(SPItemEventProperties properties)
        {
            double valor;
            double.TryParse(properties.ListItem["Importe"].ToString(), out valor);
            UpdatePropertyBag(properties.Web,-valor);
        }
    }

}

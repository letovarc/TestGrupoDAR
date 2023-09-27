using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class _Default : Page
    {
        class Persona
        {
            public int idCliente { get; set; }

            public String PrimerApellido { get; set; }

            public String SegundoApellido { get; set; }

            public String Nombres { get; set; }

            public String Sexo { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            fecha.InnerText = "El sistema corrió por primera vez a las " + DateTime.Now.ToString();

            ObtenerDatos(false);
        }

        private void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlModificado = sender as DropDownList;

            String idCliente = ddlModificado.ID.Replace("combo", "");

            int porcentajeHombres = 0;

            int porcentajeMujeres = 0;

            String cliente = "Registro modificado: ";

            foreach (TableRow item in Table1.Rows)
            {
                if (item.Cells[0].Text == "Primer Apellido")
                {

                }
                else
                {
                    DropDownList ddl = (DropDownList)item.Cells[3].Controls[0];

                    if (ddl.SelectedValue == "M")
                    {
                        porcentajeHombres++;
                    }
                    else if (ddl.SelectedValue == "F")
                    {
                        porcentajeMujeres++;
                    }
                }
            }

            TableRow r = new TableRow();
            r = (TableRow)Table1.FindControl(ddlModificado.ID).Parent.Parent;

            cliente += r.Cells[0].Text + " " + r.Cells[1].Text + " " + r.Cells[2].Text + " " + r.Cells[3].Text;

            cliente += " " + "(" + ddlModificado.SelectedValue + ")";

            cliente += " " + "M: " + (porcentajeHombres * 100) / 30 + "%" + " F: " + (porcentajeMujeres * 100) / 30 + "%";

            registroModificado.InnerText = cliente;
        }

        void ObtenerDatos(Boolean changed)
        {
            var json = new WebClient().DownloadString("https://pos.dermalia.mx/webforms/data");

            var datos = JsonConvert.DeserializeObject<List<Persona>>(json);

            for (int i = 0; i < datos.ToList().Count; i++)
            {
                TableRow r = new TableRow();
                r.BorderStyle = BorderStyle.Solid;
                r.BorderColor = System.Drawing.Color.Black;
                r.BorderWidth = Unit.Pixel(1);

                TableCell c1 = new TableCell();
                c1.Text = datos.ToList()[i].PrimerApellido;
                c1.BackColor = System.Drawing.Color.Red;
                r.Cells.Add(c1);

                TableCell c2 = new TableCell();
                c2.Text = datos[i].SegundoApellido;
                r.Cells.Add(c2);

                TableCell c3 = new TableCell();
                c3.Text = datos[i].Nombres;
                r.Cells.Add(c3);

                TableCell c4 = new TableCell();

                DropDownList ddl = new DropDownList();
                ddl.ID = "combo" + datos[i].idCliente;
                ddl.AutoPostBack = true;
                ddl.Items.Add(new ListItem("Masculino", "M"));
                ddl.Items.Add(new ListItem("Femenino", "F"));
                ddl.SelectedIndex = datos[i].Sexo == "M" ? 0 : 1;
                ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);

                c4.Controls.Add(ddl);
                r.Cells.Add(c4);

                Table1.Rows.Add(r);
            }
        }
    }
}
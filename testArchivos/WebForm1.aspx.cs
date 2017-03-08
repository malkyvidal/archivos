using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testArchivos.Models;
using System.Web.UI.HtmlControls;
namespace testArchivos
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private bool esEdicion;
        
        private bool estoyEditando()
        {
            return esEdicion;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //verificarEdicion();
            cargarArchivos();
        }

        private void verificarEdicion()
        {
            esEdicion = true;
        }

        private void cargarArchivos()
        {

            foreach (var item in obtenerLista())
            {
                FileUpload file = obtenerfileUpload(item);
                RequiredFieldValidator validator = obtenerValidator(file);
                HtmlInputButton btnLimpiar = obtenerBoton(file);
                configuracionesEdicion(Panel1, file, validator, btnLimpiar, item);
                Panel1.Controls.Add(file);
                Panel1.Controls.Add(validator);
                Panel1.Controls.Add(btnLimpiar);
            }
        }
       
        private void configuracionesEdicion(Panel pnl,FileUpload file,RequiredFieldValidator validator,HtmlInputButton  btn,DatosArchivo d)
        {
            if (esEdicion)
            {
                HtmlAnchor a = obternerLink(d);
                configuararVisibilidadEnEdicion(file);
                btn.Attributes.Add("class", "oculto");
                desabilitarValidatorEnEdicion(validator);

                pnl.Controls.Add(a);
                pnl.Controls.Add(obtenerBotonCambiar());




            }
        }


        private HtmlAnchor obternerLink(DatosArchivo d)
        {
            HtmlAnchor a = new HtmlAnchor();
            a.HRef = d.Link;
            a.InnerHtml = d.Descripcion;
            return a;
        }
        private HtmlInputButton obtenerBotonCambiar()
        {
            HtmlInputButton btnCambiar = new HtmlInputButton();
            btnCambiar.CausesValidation = false;
            btnCambiar.Value = "Cambiar";
            btnCambiar.Attributes.Add("class", "btnCambiar");
            return btnCambiar;
        }
        private FileUpload obtenerfileUpload(DatosArchivo d)
        {
            FileUpload file = new FileUpload() { ID = d.idTipoArchivo.ToString() };
            file.Attributes.Add("class", "file");
            return file;
        }
        private RequiredFieldValidator obtenerValidator(FileUpload file)
        {
            RequiredFieldValidator validator = new RequiredFieldValidator() {ErrorMessage="*", ControlToValidate = file.ClientID, ForeColor = System.Drawing.Color.Red };
            
            return validator;
        }

        private HtmlInputButton obtenerBoton(FileUpload file)
        {
            HtmlInputButton btn = new HtmlInputButton();
            btn.Value = "Limpiar";
            btn.Attributes.Add("class", "btnLimpiar");
            btn.CausesValidation = false;
           
            return btn;
        }
        private void configuararVisibilidadEnEdicion(WebControl wc)
        {
            wc.CssClass = "oculto";
        }
        private void desabilitarValidatorEnEdicion(WebControl wc)
        {
            wc.Enabled = false;

        }

        private List<DatosArchivo> obtenerLista()
        {
            return new List<DatosArchivo>() { 
            
                new DatosArchivo{idTipoArchivo=1,Descripcion="Fotocopia Dni.pdf",Link="images/archivo.pdf"},
                new DatosArchivo{idTipoArchivo=2,Descripcion="Estudios.pdf",Link="images/archivo.pdf"},
                new DatosArchivo{idTipoArchivo=3,Descripcion="CV.pdf",Link="images/archivo.pdf"}
            
            };
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (var item in Panel1.Controls)
            {
                if (item.GetType()==typeof(FileUpload))
                {
                    FileUpload f = (FileUpload)item;
                    if (f.HasFile)
                    {
                        Response.Write(f.ID);
                    }
                    
                }
            }
        }
    }
}
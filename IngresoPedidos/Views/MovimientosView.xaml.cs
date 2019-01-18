﻿using System;
using System.Windows;

namespace IngresoPedidos.Views
{
    /// <summary>
    /// Interaction logic for MovimientosView.xaml
    /// </summary>
    public partial class MovimientosView : Window
    {
        public MovimientosView()
        {
            InitializeComponent();
            tbMovimientos.Text = "26/12/2018 - 14:43:00 : {0945} : INGRESO AL SISTEMA" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0945} : FALTANTE DE COMPONENTES" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0254} : AUTORIZADO" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0712} : LICENCIA ASIGNADA [1011][AUTORIZADO POR DIEGO V.] " + Environment.NewLine + "26/12/2018 - 15:12:00 : {0712} : LICENCIA ASIGNADA [1528]" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0712} : LICENCIA ASIGNADA [0000]" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0945} : DISPONIBLE" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0623} : PRODUCCION INICIADA" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0623} : PRODUCCION PAUSADA [PEDIDO CON MAS PRIORIDAD]" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0623} : PRODUCCION CANCELADA [N/A]" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0623} : PRODUCCION REANUDADA" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0623} : PRODUCCION FINALIZADA" + Environment.NewLine + "26/12/2018 - 15:12:00 : {0945} : DESPACHADO";

        }
    }
}
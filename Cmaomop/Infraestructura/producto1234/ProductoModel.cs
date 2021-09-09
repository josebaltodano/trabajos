using Domain.Empity;
using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructura.producto1234
{
    public class ProductoModel
    {
        private Producto[] productos;
   
        public void Add(Producto p)
        {
            Add(p, ref productos);
        }
        private void Add(Producto p, ref Producto[] pds)
        {
            if (pds == null)
            {
                pds = new Producto[1];
                pds[pds.Length - 1] = p;
                return;

            }
            Producto[] tmp = new Producto[pds.Length + 1];
            Array.Copy(pds, tmp, pds.Length);
            pds = tmp;
        }

        private int GetIndexById(Producto p)
        {
            if (p == null)
            {
                throw new ArgumentException("El producto no puede ser null");
            }
            int index = int.MinValue;
            if (productos == null)
            {
                return index;

            }
            int i = 0;
            foreach (Producto pd in productos)
            {
                if (pd.Id == p.Id)
                {
                    index = i;
                    break;
                }
                i++;

            }
            return index;

        }
        public int Update(Producto p)
        {
            int index = GetIndexById(p);
            if (index < 0)
            {
                throw new ArgumentException($"EL producto con Id {p.Id} no se encontro");
            }
            productos[index] = p;
            return index;
        }
        public bool paraborrarareeglos(Producto p)
        {
            int index = GetIndexById(p);
            if (index < 0)
            {
                throw new ArgumentException($"EL producto con Id {p.Id} no se encontro");
            }
            if (index != productos.Length - 1)
            {
                productos[index] = productos[productos.Length - 1];
            }
            productos[index] = productos[productos.Length - 1];
            Producto[] tmp = new Producto[productos.Length - 1];
            Array.Copy(productos, tmp, tmp.Length);
            productos = tmp;

            return productos.Length == tmp.Length;

        }
        public Producto[] GetAll()
        {
            return productos;
        }
        #region Queries
        
        public Producto GetProductoBydy(int id)
        {
            Array.Sort(productos, new Producto.ProductoIdCompare());
            int index = Array.BinarySearch(productos, id);
            return index < 0 ? null : productos[index];
        }
        public Producto [] GetProductosbyUnidadMedida(UnidadMedida um)
        {
            Producto[] tmp = null;
            foreach(Producto p in productos)
            {
                if (p.medida == um)
                {
                    Add(p, ref tmp);
                }
            }
            return tmp;
        }
        public Producto[] GetProductosByFechadevencimiento(DateTime dt)
        {
            Producto[] tmp = null;
            if (productos == null)
            {
                return tmp;
            }
            foreach(Producto p in productos)
            {
                if (p.Vencimiento.CompareTo(dt)<= 0)
                {
                    Add(p, ref tmp);
                       
                }
            }
            return tmp;
        }
        public Producto[] GetProductosByrangodeprecio(decimal start,decimal end)
        {
            Producto[] tmp = null;
            if(productos == null)
            {
                return tmp;
            }
            foreach(Producto p in productos)
            {
                if(p.Precio >= start &&p.Precio <= end)
                {
                    Add(p, ref tmp);
                }
                    
                    
            }
            return tmp;
        }
        public string GetProductosByJson()
        {
            return JsonConvert.SerializeObject(productos);
        }
        public Producto [] GetProductosOrderByprecio()
        {
            Array.Sort(productos, new Producto.productoOrderByprecio());
            return productos;
        }
        #endregion

    }



}

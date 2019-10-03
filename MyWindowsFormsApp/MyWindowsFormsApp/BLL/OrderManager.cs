using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MyWindowsFormsApp.Repository;
using MyWindowsFormsApp.Model;

namespace MyWindowsFormsApp.BLL
{
    class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        public bool Add(Order order)
        {
            return _orderRepository.Add(order);
        }

        public DataTable Display()
        {
            return _orderRepository.Display();
        }

        public DataTable ItemCombo()
        {
            return _orderRepository.ItemCombo();
        }
        public DataTable CustomerCombo()
        {
            return _orderRepository.CustomerCombo();
        }
        public double TotalPrice(int quantity,string item)
        {
            return  quantity*_orderRepository.TotalPrice(item);
        }

    }
}

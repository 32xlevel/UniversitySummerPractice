using System;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ArrangeThisQualifier
// ReSharper disable NotAccessedField.Global

namespace Task09
{
    public class Node
    {
        public int? Data;
        public Node Next;

        public int Length
        {
            get
            {
                var count = 0;
                var temp = this;
                while (temp.Next != null) count++;

                return count;
            }
        }

        public Node()
        {
            this.Data = null;
            this.Next = null;
        }

        public Node Add(int data)
        {
            if (data > 0)
            {
                var node = AddToStart(data);
                return node;
            }
            else if (data < 0)
            {
                var node = AddToEnd(data);
                return node;
            }
            else
            {
                var lastPositive = GetLastPositive();
                if (lastPositive == null) return AddToStart(0);
                            
                var nextOfLastPositive = lastPositive.Next;
                            
                var node = new Node();
                node.Data = 0;
                lastPositive.Next = node;
                node.Next = nextOfLastPositive;
                            
                return this;
            }
        }
        
        /*
         * Метод удаляет элемент по указанному индексу    
         */
        public Node RemoveAt(int index)
        {
            if (index < 0) throw new ArgumentException($"index должен быть неотрицательным. Передано: {index}");
            if (this.Length - 1 < index) throw new ArgumentException($"Переданный index (равный {index}) превышает максимально допустимый (равный {this.Length - 1})");
            
            if (index == 0) return this.Next; // Краевой случай
            else if (index == this.Length - 1) // Краевой случай
            {
                var head = this;
                var temp = head;
                var count = 0;

                while (count != index - 1)
                {
                    temp = temp.Next;
                    count++;
                }

                temp.Next = null;
                return head;
            }
            else
            {
                var head = this;
                var temp = head;
                var count = 0;
                
                while (count != index - 1)
                {
                    temp = temp.Next;
                    count++;
                }
                
                temp.Next = temp.Next.Next;
                            
                return head;
            }
        }

        public bool IsExist(int data)
        {
            var temp = this;
            while (temp != null)
            {
                if (temp.Data == data) return true;
                temp = temp.Next;
            }
            
            return false;
        }

        public Node GetAt(int index)
        {
            if (index < 0) throw new ArgumentException($"index должен быть неотрицательным. Передано: {index}");
            if (this.Length - 1 < index) throw new ArgumentException($"Переданный index (равный {index}) превышает максимально допустимый (равный {this.Length - 1})");

            var count = 0;
            var temp = this;
            while (count != index)
            {
                temp = temp.Next;
                count++;
            }
            
            return temp;
        }

        /*
         * Метод, возвращающий индекс первого элемента, информационное поле которого равно data
         * Если такого информационного поля нет ни в одном из элементов, возвращает -1
         */
        public int GetIndexOf(int data)
        {
            var count = 0;
            var temp = this;
            while (temp != null)
            {
                if (temp.Data == data) return count;
                temp = temp.Next;
                count++;
            }
            
            return -1;
        }
        
        private Node AddToStart(int data)
        {
            return new Node
            {
                Data = data, 
                Next = this
            };
        }

        private Node AddToEnd(int data)
        {
            var node = new Node();
            node.Data = data;

            var last = GetLast();
            last.Next = node;

            return this;
        }

        private Node GetLast()
        {
            var temp = this;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            return temp;
        }

        private Node GetLastPositive()
        {
            var temp = this;
            while (temp.Next != null && temp.Next.Data > 0)
            {
                temp = temp.Next;
            }

            return temp.Data > 0 ? temp : null; // Проверка - если ли вообще положительные элементы?
        }

        public override string ToString()
        {
            var result = "";
            var node = this;
            while (node != null)
            {
                result += $"{node.Data} -> ";
                node = node.Next;
            }

            result += "null";
            return result;
        }
    }
}
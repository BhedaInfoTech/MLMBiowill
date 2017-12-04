using MLMBiowillBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLMBioWill.Common
{
    public class MessageStore
    {
        public static FixedSizeGenericHashTable<string, FriendlyMessage> hash = new FixedSizeGenericHashTable<string, FriendlyMessage>(400);

        static MessageStore()
        {
            #region System

            FriendlyMessage SYS01 = new FriendlyMessage("SYS01", MessageType.Error, "We are currently unable to process your request, Please try again later or contact system administrator.");
            hash.Add("SYS01", SYS01);

            FriendlyMessage SYS02 = new FriendlyMessage("SYS02", MessageType.Information, "Your session has expired. Please login again.");
            hash.Add("SYS02", SYS02);

            FriendlyMessage SYS03 = new FriendlyMessage("SYS03", MessageType.Error, "Please login with valid Username & Password to view this page.");
            hash.Add("SYS03", SYS03);

            FriendlyMessage SYS04 = new FriendlyMessage("SYS04", MessageType.Information, "No records found.");
            hash.Add("SYS04", SYS04);

            FriendlyMessage SYS05 = new FriendlyMessage("SYS05", MessageType.Information, "Password has been changed successfully.");
            hash.Add("SYS05", SYS05);

            FriendlyMessage SYS06 = new FriendlyMessage("SYS06", MessageType.Error, "You dont have online access. Please contact administrator.");
            hash.Add("SYS06", SYS06);

            FriendlyMessage SYS07 = new FriendlyMessage("SYS07", MessageType.Error, "File not found, Please contact administrator.");
            hash.Add("SYS07", SYS07);

            FriendlyMessage SYS08 = new FriendlyMessage("SYS08", MessageType.Error, "Entered User is not an Valid Active directory Member");
            hash.Add("SYS08", SYS08);

            FriendlyMessage SYS010 = new FriendlyMessage("SYS010", MessageType.Information, "You have successfully logged out!");
            hash.Add("SYS010", SYS010);

            FriendlyMessage SYS011 = new FriendlyMessage("SYS011", MessageType.Information, "You dont have access to this functionality.");
            hash.Add("SYS011", SYS011);

            #endregion

            #region Category

            FriendlyMessage CATEGORY01 = new FriendlyMessage("CATEGORY01", MessageType.Success, "Category added successfully.");
            hash.Add("CATEGORY01", CATEGORY01);

            FriendlyMessage CATEGORY02 = new FriendlyMessage("CATEGORY02", MessageType.Success, "Category updated successfully.");
            hash.Add("CATEGORY02", CATEGORY02);

            FriendlyMessage CATEGORY03 = new FriendlyMessage("CATEGORY03", MessageType.Information, "No records found.");
            hash.Add("CATEGORY03", CATEGORY03);

            #endregion

            #region SubSUBCATEGORY

            FriendlyMessage SUBCATEGORY01 = new FriendlyMessage("SUBCATEGORY01", MessageType.Success, "SUBCATEGORY added successfully.");
            hash.Add("SUBCATEGORY01", SUBCATEGORY01);

            FriendlyMessage SUBCATEGORY02 = new FriendlyMessage("SUBCATEGORY02", MessageType.Success, "SUBCATEGORY updated successfully.");
            hash.Add("SUBCATEGORY02", SUBCATEGORY02);

            FriendlyMessage SUBCATEGORY03 = new FriendlyMessage("SUBCATEGORY03", MessageType.Information, "No records found.");
            hash.Add("SUBCATEGORY03", SUBCATEGORY03);

            #endregion

            #region Bank

            FriendlyMessage BANK01 = new FriendlyMessage("BANK01", MessageType.Success, "BANK added successfully.");
            hash.Add("BANK01", BANK01);

            FriendlyMessage BANK02 = new FriendlyMessage("BANK02", MessageType.Success, "BANK updated successfully.");
            hash.Add("BANK02", BANK02);

            FriendlyMessage BANK03 = new FriendlyMessage("BANK03", MessageType.Information, "No records found.");
            hash.Add("BANK03", BANK03);

            #endregion

            #region Branch

            FriendlyMessage BRANCH01 = new FriendlyMessage("BRANCH01", MessageType.Success, "BRANCH added successfully.");
            hash.Add("BRANCH01", BRANCH01);

            FriendlyMessage BRANCH02 = new FriendlyMessage("BRANCH02", MessageType.Success, "BRANCH updated successfully.");
            hash.Add("BRANCH02", BRANCH02);

            FriendlyMessage BRANCH03 = new FriendlyMessage("BRANCH03", MessageType.Information, "No records found.");
            hash.Add("BRANCH03", BRANCH03);

            #endregion

            #region Designation

            FriendlyMessage DESIGNATION01 = new FriendlyMessage("DESIGNATION01", MessageType.Success, "DESIGNATION added successfully.");
            hash.Add("DESIGNATION01", DESIGNATION01);

            FriendlyMessage DESIGNATION02 = new FriendlyMessage("DESIGNATION02", MessageType.Success, "DESIGNATION updated successfully.");
            hash.Add("DESIGNATION02", DESIGNATION02);

            FriendlyMessage DESIGNATION03 = new FriendlyMessage("DESIGNATION03", MessageType.Information, "No records found.");
            hash.Add("DESIGNATION03", DESIGNATION03);

            #endregion

            #region Depatment

            FriendlyMessage DEPARTMENT01 = new FriendlyMessage("DEPARTMENT01", MessageType.Success, "DEPARTMENT added successfully.");
            hash.Add("DEPARTMENT01", DEPARTMENT01);

            FriendlyMessage DEPARTMENT02 = new FriendlyMessage("DEPARTMENT02", MessageType.Success, "DEPARTMENT updated successfully.");
            hash.Add("DEPARTMENT02", DEPARTMENT02);

            FriendlyMessage DEPARTMENT03 = new FriendlyMessage("DEPARTMENT03", MessageType.Information, "No records found.");
            hash.Add("DEPARTMENT03", DEPARTMENT03);

            #endregion

            #region Country

            FriendlyMessage Country01 = new FriendlyMessage("Country01", MessageType.Success, "Country added successfully.");
            hash.Add("Country01", Country01);

            FriendlyMessage Country02 = new FriendlyMessage("Country02", MessageType.Success, "Country updated successfully.");
            hash.Add("Country02", Country02);

            FriendlyMessage Country03 = new FriendlyMessage("Country03", MessageType.Information, "No records found.");
            hash.Add("Country03", Country03);

            #endregion

            #region State

            FriendlyMessage STATE01 = new FriendlyMessage("STATE01", MessageType.Success, "State added successfully.");
            hash.Add("STATE01", STATE01);

            FriendlyMessage STATE02 = new FriendlyMessage("STATE02", MessageType.Success, "State updated successfully.");
            hash.Add("STATE02", STATE02);

            FriendlyMessage STATE03 = new FriendlyMessage("STATE03", MessageType.Information, "No records found.");
            hash.Add("STATE03", STATE03);

            #endregion

            #region City

            FriendlyMessage CITY01 = new FriendlyMessage("CITY01", MessageType.Success, "City added successfully.");
            hash.Add("CITY01", CITY01);

            FriendlyMessage CITY02 = new FriendlyMessage("CITY02", MessageType.Success, "City updated successfully.");
            hash.Add("CITY02", CITY02);

            FriendlyMessage CITY03 = new FriendlyMessage("CITY03", MessageType.Information, "No records found.");
            hash.Add("CITY03", CITY03);

            #endregion

            #region Company
            FriendlyMessage Comp01 = new FriendlyMessage("Comp01", MessageType.Success, "Company added successfully.");
            hash.Add("Comp01", Comp01);

            FriendlyMessage Comp02 = new FriendlyMessage("Comp02", MessageType.Success, "Company updated successfully.");
            hash.Add("Comp02", Comp02);

            FriendlyMessage Comp03 = new FriendlyMessage("Comp03", MessageType.Information, "No records found.");
            hash.Add("Comp03", Comp03);

            #endregion

            #region Address
            FriendlyMessage Add01 = new FriendlyMessage("Add01", MessageType.Success, "Address added successfully.");
            hash.Add("Add01", Add01);

            FriendlyMessage Add02 = new FriendlyMessage("Add02", MessageType.Success, "Address updated successfully.");
            hash.Add("Add02", Add02);

            FriendlyMessage Add03 = new FriendlyMessage("Add03", MessageType.Information, "Address deleted successfully.");
            hash.Add("Add03", Add03);

            FriendlyMessage Add04 = new FriendlyMessage("Add04", MessageType.Information, "No records found.");
            hash.Add("Add04", Add04);

            #endregion
                           
            #region Contact Details
            FriendlyMessage Cont01 = new FriendlyMessage("Cont01", MessageType.Success, "Contact Details added successfully.");
            hash.Add("Cont01", Cont01);

            FriendlyMessage Cont02 = new FriendlyMessage("Cont02", MessageType.Success, "Contact Details updated successfully.");
            hash.Add("Cont02", Cont02);

            FriendlyMessage Cont03 = new FriendlyMessage("Cont03", MessageType.Information, "Contact Details deleted successfully.");
            hash.Add("Cont03", Cont03);

            FriendlyMessage Cont04 = new FriendlyMessage("Cont04", MessageType.Information, "No records found.");
            hash.Add("Cont04", Cont04);

            #endregion

            #region ContactPerson Details
            FriendlyMessage ContPer01 = new FriendlyMessage("ContPer01", MessageType.Success, "ContactPerson Details added successfully.");
            hash.Add("ContPer01", ContPer01);

            FriendlyMessage ContPer02 = new FriendlyMessage("ContPer02", MessageType.Success, "ContactPerson Details updated successfully.");
            hash.Add("ContPer02", ContPer02);

            FriendlyMessage ContPer03 = new FriendlyMessage("ContPer03", MessageType.Information, "ContactPerson Details deleted successfully.");
            hash.Add("ContPer03", ContPer03);

            FriendlyMessage ContPer04 = new FriendlyMessage("ContPer04", MessageType.Information, "No records found.");
            hash.Add("ContPer04", ContPer04);

            #endregion

            #region User

            FriendlyMessage U01 = new FriendlyMessage("U01", MessageType.Success, "User added successfully.");
            hash.Add("U01", U01);

            FriendlyMessage U02 = new FriendlyMessage("U02", MessageType.Success, "User updated successfully.");
            hash.Add("U02", U02);

            FriendlyMessage U03 = new FriendlyMessage("U03", MessageType.Information, "No records found.");

            hash.Add("U03", U03);

            #endregion

            #region User Login

            FriendlyMessage UM001 = new FriendlyMessage("UM001", MessageType.Warning, "Username and password does not match. Please Login again.");
            hash.Add("UM001", UM001);

            FriendlyMessage UM002 = new FriendlyMessage("UM002", MessageType.Success, "User has been added successfully. please check your Email to Activate start using your account");
            hash.Add("UM002", UM002);

            FriendlyMessage UM003 = new FriendlyMessage("UM003", MessageType.Success, "User has been updated successfully.");
            hash.Add("UM003", UM003);

            FriendlyMessage UM004 = new FriendlyMessage("UM004", MessageType.Warning, "User Session has been Expired. Please Login again.");
            hash.Add("UM004", UM004);

            FriendlyMessage UM005 = new FriendlyMessage("UM005", MessageType.Information, "User can now login with User name and Created password.");
            hash.Add("UM005", UM005);

            FriendlyMessage UM006 = new FriendlyMessage("UM006", MessageType.Information, "please check your Email to Reset password and start using your account");
            hash.Add("UM006", UM006);

            FriendlyMessage UM007 = new FriendlyMessage("UM007", MessageType.Warning, "User is InActive. Contact system administrator.");
            hash.Add("UM007", UM007);

            #endregion

            #region Role

            FriendlyMessage Ro01 = new FriendlyMessage("Ro01", MessageType.Success, "Role added successfully.");
            hash.Add("Ro01", Ro01);

            FriendlyMessage Ro02 = new FriendlyMessage("Ro02", MessageType.Success, "Role updated successfully.");
            hash.Add("Ro02", Ro02);

            FriendlyMessage Ro03 = new FriendlyMessage("Ro03", MessageType.Information, "No records found.");
            hash.Add("Ro03", Ro03);

            #endregion


            #region Authentication

            FriendlyMessage AUTHENTICATION01 = new FriendlyMessage("AUTHENTICATION01", MessageType.AcessDenied, "Sorry, you don't have permission to access on this server.");
            hash.Add("AUTHENTICATION01", AUTHENTICATION01);

            #endregion

            #region Accessories

            FriendlyMessage ACCESSORIES01 = new FriendlyMessage("ACCESSORIES01", MessageType.Success, "File uploaded successfully.");
            hash.Add("ACCESSORIES01", ACCESSORIES01);

            FriendlyMessage ACCESSORIES02 = new FriendlyMessage("ACCESSORIES02", MessageType.Success, "File deleted successfully.");
            hash.Add("ACCESSORIES02", ACCESSORIES02);

            #endregion

            #region Warehouse

            FriendlyMessage WAREHOUSE01 = new FriendlyMessage("WAREHOUSE01", MessageType.Success, "Warehouse added successfully.");
            hash.Add("WAREHOUSE01", WAREHOUSE01);

            FriendlyMessage WAREHOUSE02 = new FriendlyMessage("WAREHOUSE02", MessageType.Success, "Warehouse updated successfully.");
            hash.Add("WAREHOUSE02", WAREHOUSE02);

            FriendlyMessage WAREHOUSE03 = new FriendlyMessage("WAREHOUSE03", MessageType.Information, "No records found.");
            hash.Add("WAREHOUSE03", WAREHOUSE03);

            #endregion
           
        }

        public static FriendlyMessage Get(string code)
        {
            FriendlyMessage message = hash.Find(code);

            return message;
        }

        /// <summary>
        /// struct to hold generic key and value
        /// </summary>
        /// <typeparam name="K">Key</typeparam>
        /// <typeparam name="V">Value</typeparam>
        /// <remarks></remarks>
        /// 
        public struct KeyValue<K, V>
        {
            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
            /// <remarks></remarks>
            public K Key
            {
                get;
                set;
            }
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            /// <remarks></remarks>
            public V Value
            {
                get;
                set;
            }
        }

        /// <summary>
        /// FixedSizeGenericHashTable
        /// </summary>
        /// <typeparam name="K">Key</typeparam>
        /// <typeparam name="V">Value</typeparam>
        /// <remarks>Object for FixedSizeGenericHashTable of key K and of value V</remarks>
        public class FixedSizeGenericHashTable<K, V>
        {
            private readonly int size;
            private readonly LinkedList<KeyValue<K, V>>[] items;

            public FixedSizeGenericHashTable(int size)
            {
                this.size = size;
                items = new LinkedList<KeyValue<K, V>>[size];
            }

            protected int GetArrayPosition(K key)
            {
                int position = key.GetHashCode() % size;
                return Math.Abs(position);
            }

            public V Find(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }

                return default(V);
            }

            /// <summary>
            /// Adds the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="value">The value.</param>
            /// <remarks></remarks>
            public void Add(K key, V value)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                KeyValue<K, V> item = new KeyValue<K, V>()
                {
                    Key = key,
                    Value = value
                };
                linkedList.AddLast(item);
            }

            /// <summary>
            /// Removes the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <remarks></remarks>
            public void Remove(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                bool itemFound = false;
                KeyValue<K, V> foundItem = default(KeyValue<K, V>);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        itemFound = true;
                        foundItem = item;
                    }
                }

                if (itemFound)
                {
                    linkedList.Remove(foundItem);
                }
            }

            /// <summary>
            /// Gets the linked list.
            /// </summary>
            /// <param name="position">The position.</param>
            /// <returns></returns>
            /// <remarks></remarks>
            protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
            {
                LinkedList<KeyValue<K, V>> linkedList = items[position];
                if (linkedList == null)
                {
                    linkedList = new LinkedList<KeyValue<K, V>>();
                    items[position] = linkedList;
                }

                return linkedList;
            }
        }
    }
}
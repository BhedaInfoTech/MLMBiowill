﻿using MLMBiowillBusinessEntities.Common;
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

            #region Country

            FriendlyMessage COUNTRY01 = new FriendlyMessage("COUNTRY01", MessageType.Success, "Country added successfully.");
            hash.Add("COUNTRY01", COUNTRY01);

            FriendlyMessage COUNTRY02 = new FriendlyMessage("COUNTRY02", MessageType.Success, "Country updated successfully.");
            hash.Add("COUNTRY02", COUNTRY02);

            FriendlyMessage COUNTRY03 = new FriendlyMessage("COUNTRY03", MessageType.Information, "No records found.");
            hash.Add("COUNTRY03", COUNTRY03);

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
            FriendlyMessage COMPANY01 = new FriendlyMessage("COMPANY01", MessageType.Success, "Company added successfully.");
            hash.Add("COMPANY01", COMPANY01);

            FriendlyMessage COMPANY02 = new FriendlyMessage("COMPANY02", MessageType.Success, "Company updated successfully.");
            hash.Add("COMPANY02", COMPANY02);

            FriendlyMessage COMPANY03 = new FriendlyMessage("COMPANY03", MessageType.Information, "No records found.");
            hash.Add("COMPANY03", COMPANY03);

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
using System;
using UnityEngine;

namespace CrashedWorld.Attribute
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class ItemAttribute : PropertyAttribute
    {

    }
}



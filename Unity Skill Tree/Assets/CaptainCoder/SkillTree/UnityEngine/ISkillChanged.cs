using System.Collections.Generic;

namespace CaptainCoder.SkillTree.UnityEngine
{
    public interface ISkillChanged
    {
        /// <summary>
        /// This event fires when a skill is acquired. The resulting action should contain
        /// a guid string and a hash set of guids for all skills that are owned.
        /// </summary>
        public event System.Action<string, HashSet<string>> OnSkillAcquired;
    }
    
}
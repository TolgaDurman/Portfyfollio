using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class JumpEvent : BoxEvents
    {
        private Rigidbody jumper;

        public JumpEvent(Rigidbody jumper)
        {
            this.jumper = jumper;
        }

        public override void OnEventExecute()
        {
            JumpJumper();
        }

        private void JumpJumper()
        {
            jumper.AddForce(Vector3.up * 150f);
        }
    }
}

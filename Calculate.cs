using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单计算
{
    class Calculate
    {
        private int frontFlag = 0;
        private static double FirstRecordDot = 0.1;
        private static double SecondRecordDot = 0.1;

        public double? FrontNum { get; set; }
        public double? LastNum { get; set; }
        public char CalcOperator { get; set; }//操作符
        public char FirstDot { get; set; }//第一个数小数点
        public char SecondDot { get; set; }//第一个数小数点

        public Calculate()
        {
            FrontNum = 0;
            LastNum = null;
            CalcOperator = '0';
            FirstDot = '0';
            SecondDot = '0';
        }

        public void SetNum(double para)//由数字按键调用
        {
            if (frontFlag == 0 && CalcOperator=='0')
            { 
                FrontNum = 0;
                frontFlag = 1;
            }
            if (CalcOperator == '0')
            {
                if (FirstDot == '.')
                {
                    FrontNum = FrontNum  + para * FirstRecordDot;
                    FirstRecordDot /= 10;
                }
                else
                    FrontNum = FrontNum * 10 + para;
            }
            else if (LastNum == null)
            {
                LastNum = para;
                frontFlag = 0;
            }
            else
            {
                if (SecondDot == '.')
                {
                    LastNum = LastNum + para * SecondRecordDot;
                    SecondRecordDot /= 10;
                }
                else
                    LastNum = LastNum * 10 + para;
            }
        }

        public void SetOperator_Calc(char para)//由操作符按键（除去等于号）调用
        {

            if (this.CalcOperator != '0' && this.LastNum != 0)
            {
                HowToCalc();
                this.CalcOperator = para;
                this.LastNum = null;
                FirstRecordDot = 0.1;
                SecondRecordDot = 0.1;
                FirstDot = '0';
                SecondDot = '0';
            }
            else
            {
                this.CalcOperator = para;
                return;
            }
        }
        private void HowToCalc()
        {
            switch(CalcOperator)
            {
                case '+':FrontNum += LastNum; break;
                case '-':FrontNum -= LastNum; break;
                case '×':FrontNum *= LastNum; break;
                case '÷':
                    {
                    if(LastNum!=0)FrontNum /= LastNum; 
                    else
                    {
                        this.FrontNum = 0;
                        this.CalcOperator = '0';
                        this.LastNum = null;
                    }
                    break;
                    }
                default:break;
            }
        }

        public void Echo()//等于按键调用
        {
            if (CalcOperator != '0')
            {
                HowToCalc();
                this.CalcOperator = '0';
                this.LastNum = null;
                FirstRecordDot = 0.1;
                SecondRecordDot = 0.1;
                FirstDot = '0';
                SecondDot = '0';
            }
            else
                return ;
        }

        public void Delete()//C按键调用（清除）
        {
            this.FrontNum = 0;
            this.CalcOperator = '0';
            this.LastNum = null;
            FirstRecordDot = 0.1;
            SecondRecordDot = 0.1;
            FirstDot = '0';
            SecondDot = '0';
        }
    }
}

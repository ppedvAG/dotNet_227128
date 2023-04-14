namespace HalloAsync
{
    delegate void EinfacherDelegate();
    delegate void DeleMitPara(string text);
    delegate long CalcDele(int a, int b);

    internal class HalloDelegate
    {
        event DeleMitPara MyEveent;
        public HalloDelegate()
        {
            EinfacherDelegate meinDelegate = EinfacheMethode;
            Action meinDeleAlsAction = EinfacheMethode;
            Action meinDeleAlsActionAno = delegate () { Console.WriteLine("Hallo"); };
            Action meinDeleAlsActionAno2 = () => { Console.WriteLine("Hallo"); };
            Action meinDeleAlsActionAno3 = () => Console.WriteLine("Hallo");

            DeleMitPara deleMitPara = MethodeMitPara;
            Action<string> deleMitParaAlsAction = MethodeMitPara;
            DeleMitPara deleMitParaAno = delegate (string txt) { Console.WriteLine(txt); };
            DeleMitPara deleMitParaAno2 = (string txt) => { Console.WriteLine(txt); };
            Action<string> deleMitParaAno3 = (txt) => Console.WriteLine(txt);
            Action<string> deleMitParaAno4 = x => Console.WriteLine(x);


            CalcDele calcDele = Minus;
            Func<int, int, long> calcDeleAlsFunc = Sum;
            CalcDele calcDeleFuncAno = delegate (int a, int b) { return a + b; };
            CalcDele calcDeleFuncAno2 = (int a, int b) => { return a + b; };
            CalcDele calcDeleFuncAno3 = (a, b) => { return a + b; };
            CalcDele calcDeleFuncAno4 = (a, b) => a + b;

            List<string> text = new List<string>();
            text.Where(x => x.StartsWith("b"));
            text.Where(MyFilter);


            deleMitPara.Invoke("AA");
            long result = calcDele.Invoke(1, 2);

            MyCaller(x => x == 2);
        }

        void MyCaller(Func<int, bool> eineFunc)
        {
            if (eineFunc.Invoke(1))
                eineFunc.Invoke(2);
        }

        private bool MyFilter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void MethodeMitPara(string msg)
        {
            Console.WriteLine(msg);
        }

        public void EinfacheMethode()
        {
            Console.WriteLine("Hallo");
        }
    }
}

namespace Storage
{
    internal class Task
    {
        public Task(String name, String descript)
        {
            this.name = name;
            this.descript = descript;
            state = false;
            this.responsible = string.Empty;
        }
        public void GiveInformarion()
        {
            Console.WriteLine("Название:"+name + "\r\n Описание:" +
                                 descript + "\r\n Ответсвенный:" +
                                 responsible + "\r\n Выпонено или нет:" +
                                 state);
        }
        public string name { get; }
        public string descript { get; }
        public string responsible { get; set; }
        public bool state { get; set; }
    }
}

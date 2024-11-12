namespace Storage
{
    public class Tassk
    {
        public Tassk(String name, String descript)
        {
            if (makeid == null)
                makeid = 0;
            this.title = name;
            this.description = descript;
            this.iscompleted = false;
            this.responsible = string.Empty;
            id = makeid;
            makeid++;
        }
        public Tassk()
        {
            this.title = string.Empty;
            this.description = string.Empty;
            this.iscompleted = false;
            this.responsible = string.Empty;
            id = makeid;
            makeid++;
        }

        public Tassk(String name, String descript, bool iscompleted, String responsible)
        {
            this.title = name;
            this.description = descript;
            this.iscompleted = iscompleted;
            this.responsible = responsible;
        }

        public void GiveInformarion()
        {
            Console.WriteLine("Название:"+ title + "\r\n Описание:" +
                                 description + "\r\n Ответсвенный:" +
                                 responsible + "\r\n Выпонено или нет:" +
                                 iscompleted);
        }
        private static int makeid;
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string responsible { get; set; }
        public bool iscompleted { get; set; }
    }
}

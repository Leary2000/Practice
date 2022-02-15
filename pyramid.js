
        /* first triangle buttons*/
        let counterPlusElem = document.querySelector('.increase');
        let counterDecElem = document.querySelector('.decrease');
        let counterDispElem = document.querySelector('.numDisplay');
        let num = 0;

        update();
        counterPlusElem.addEventListener("click",()=>
        {
            num++;
            update()
        })
        counterDecElem.addEventListener("click",()=>
        {
            num--;
            update()
        })
        function update(){
        counterDispElem.innerHTML = num;
                };

        /* second triangle buttons*/ 
        let counterPlusElem2 = document.querySelector('.increase2');
        let counterDecElem2 = document.querySelector('.decrease2');
        let counterDispElem2 = document.querySelector('.numDisplay2');
        let num2 = 0;

        update2();
        function increase2()
        {
            num2++;
            update2()
            console.log("update2")

        }
        counterDecElem2.addEventListener("click",()=>
        {
            num2--;
            update2()
        })
        function update2(){
        }

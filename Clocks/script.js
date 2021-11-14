let digitalElement = document.querySelector('.digital');
let secondElement = document.querySelector('.p_s');
let minuteElement = document.querySelector('.p_m');
let hourElement = document.querySelector('.p_h');
//Coleta as informações para o relógio
function updateClock()
{
   let now = new Date();
   let hour = now.getHours();
   let minute = now.getMinutes();
   let second = now.getSeconds();

   //Relógio digital
   digitalElement.innerHTML =
   `${fixZero(hour)}:
    ${fixZero(minute)}:
    ${fixZero(second)}`;

    //Relógio analógico e o cálculo para o seu funcionamento
    let vDegrees = ((360 / 60)  * second) - 90;
    let mDegrees =((360 / 60) * minute) - 90;
    let hDegrees =((360 / 12) * hour) - 90;

    secondElement.style.transform = `rotate(${vDegrees}deg)`;
    minuteElement.style.transform = `rotate(${mDegrees}deg)`;
    hourElement.style.transform = `rotate(${hDegrees}deg)`;
}

function fixZero(time)
{
   return time < 10 ? `0${time}` : time;
}
//Executa um intervaldo de tempo infinito
setInterval(updateClock, 1000);
updateClock();
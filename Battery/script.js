//Evento do clique na tela inteira
document.body.addEventListener('keyup', (event)=>{
   // Chama a função pra tocar
    playSound( event.code.toLowerCase() );
})


document.querySelector('.composer button').addEventListener('click', () =>
{
    let song = document.querySelector('#input').value;

    if(song !== '')
    {
        let songArray = song.split('');
        playComposition(songArray);
    }
});

//Função de tocar o som e acender a tecla
function playSound(sound)
{
    let audioElement = document.querySelector(`#s_${sound}`);
    let keyElement = document.querySelector(`div[data-key="${sound}"]`); 
    
    if(audioElement)
    {
        audioElement.currentTime = 0;
        audioElement.play();
      
    }

    if(keyElement)
    {
        keyElement.classList.add('active');

        setTimeout(()=>
        {
            keyElement.classList.remove('active');
        }, 300);
    }
}

//Função do botão tocar 
function playComposition(songArray)
{
    let wait = 0;

    for(let songItem of songArray)
    {
        setTimeout(()=>
        {
            playSound(`key${songItem}`);
        }, wait);

        wait += 250;
    }
}
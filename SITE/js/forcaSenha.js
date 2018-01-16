$(document).ready(function() {


var numeros="0123456789";
var letras="abcdefghyjklmnopqrstuvwxyz";
var letras_maiusculas = "ABCDEFGHYJKLMNOPQRSTUVWXYZ";
var especiais = "'!@#$%¨&*()_-+=,.;/?:><|"

var valorForca = 0;



function tem_numeros(texto){
	for(i=0; i<texto.length; i++){
		if (numeros.indexOf(texto.charAt(i),0)!=-1){
			
		valorForca += 1;
		break;

		}
	}
}

function tem_minusculas(texto){
   for(i=0; i<texto.length; i++){
      if (letras.indexOf(texto.charAt(i),0)!=-1){
         valorForca += 1;
		break;
      }
   }
  
} 


function tem_maiusculas(texto){
   for(i=0; i<texto.length; i++){
      if (letras_maiusculas.indexOf(texto.charAt(i),0)!=-1){
         valorForca += 1;
		break;
      }
   }
} 

function tem_caracteres(texto) {
    for (i = 0; i < texto.length; i++) {
        if (especiais.indexOf(texto.charAt(i), 0) != -1) {
            valorForca += 1;
            break;
        }
    }
}


$(".iconeSenhaForca").hide();
$(".dicaSenha").hide();

$(".iconeSenhaForca").click(function () {
    $(".dicaSenha").slideToggle("medium");
});


$(".txtSenha").keyup(function(){

    var senhaDigitada = $(".txtSenha").val();
    
	valorForca = 0;
	
	tem_numeros(senhaDigitada);
	tem_minusculas(senhaDigitada);
	tem_maiusculas(senhaDigitada);
	tem_caracteres(senhaDigitada);

	

	if (valorForca <= 1 || senhaDigitada.length < 6) {

	         $(".iconeSenhaForca").show();
	         $(".iconeSenhaForca").css("color", "#f0082e");
	         $(".iconeSenhaForca").attr("title", "Fraca! Saiba mais.");

	         if (senhaDigitada.length == 0) {

	             $(".iconeSenhaForca").hide();
	             
	         }


	     } else if (valorForca == 2) {

	         $(".iconeSenhaForca").show();
	         $(".iconeSenhaForca").css("color", "#E85419");
	         $(".iconeSenhaForca").attr("title", "Média! Saiba mais.");
	     } else if (valorForca == 3) {
	       
	         $(".iconeSenhaForca").show();
	         $(".iconeSenhaForca").css("color", "#089CFF");
	         $(".iconeSenhaForca").attr("title", "Forte! Saiba mais.");
	     } else {
	      
	         $(".iconeSenhaForca").show();
	         $(".iconeSenhaForca").css("color", "#19FF21");
	         $(".iconeSenhaForca").attr("title", "Muito Forte! Saiba mais.");
	     }
	
 

});




});



function validateEmail($email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test($email);
}

function soNums(e) {

    //teclas adicionais permitidas (tab,delete,backspace,setas direita e esquerda)
    keyCodesPermitidos = new Array(8, 9, 37, 39, 46);

    //numeros e 0 a 9 do teclado alfanumerico
    for (x = 48; x <= 57; x++) {
        keyCodesPermitidos.push(x);
    }

    //numeros e 0 a 9 do teclado numerico
    for (x = 96; x <= 105; x++) {
        keyCodesPermitidos.push(x);
    }

    keyCodesPermitidos.push(188);
    keyCodesPermitidos.push(190);
    keyCodesPermitidos.push(194);
    keyCodesPermitidos.push(110);


    //Pega a tecla digitada
    keyCode = e.which;

    //Verifica se a tecla digitada é permitida
    if ($.inArray(keyCode, keyCodesPermitidos) != -1) {
        return true;
    }
    return false;
}

$(document).ready(function () {
   


    tinymce.init({
        selector: '#phConteudo_descricao',
        language: 'pt_BR',
        plugins: [
          'advlist autolink lists link image charmap print preview hr anchor pagebreak',
          'searchreplace wordcount visualblocks visualchars code fullscreen',
          'insertdatetime media nonbreaking save table contextmenu directionality',
          'emoticons template paste textcolor colorpicker textpattern imagetools'
        ],
        
        toolbar: 'styleselect | forecolor bold italic | alignleft aligncenter alignright alignjustify | bullist numlist |  link image | preview'
    });


    tinymce.init({
        selector: '#phConteudo_lista',
        language: 'pt_BR',
        menubar: false,
        toolbar: 'bullist'
    });

    $('#txtPreco').bind('keydown', soNums);

    $("#pesquisaBar").hide();
    $(".btnsConfApagar").hide();

    $("#apagarConta").click(function () {
        $(".btnsConfApagar").slideToggle();
    });
    $(".btnCancApagar").click(function () {
        $(".btnsConfApagar").slideToggle();
    });
    

	$(".pesquisa").click(function(){    
		$("#pesquisaBar").slideToggle();
	});


   var maisOuMenos = 0;

		$("#categoriasOcultas").hide();



			$("#iconeMaisMenos").click(function(){           
  

	   			$("#categoriasOcultas").slideToggle();

					if(maisOuMenos == 0){

	   					$("#mudaIcone").attr("src","imgs/icones/less.png");
	   					$("#mudaIcone").attr("title", "Minimizar categorias");
	   					$("#mudaIcone").attr("alt", "Minimizar categorias")
	   					maisOuMenos = 1;

					} else {

						$("#mudaIcone").attr("src","imgs/icones/plus.png");
						$("#mudaIcone").attr("title", "Ver todas as categorias");
						$("#mudaIcone").attr("alt", "Ver todas as categorias")
						
						maisOuMenos = 0;

					}

				});

			$(".iconeSenhaDiferente").hide();

			$(".txtSenhaConf").focusout(function () {

			    if ($(".txtSenha").val() == $(".txtSenhaConf").val()) {

			        $(".iconeSenhaDiferente").hide();

			    } else {

			        $(".iconeSenhaDiferente").show();
			    }


			});


			$(".iconeEmailInvalido").hide();

			$(".txtEmail").focusout(function () {

			    $('.txtEmail').filter(function () {
			        var emil = $('.txtEmail').val();
			        var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
			        if (!emailReg.test(emil)) {

			            $(".iconeEmailInvalido").show();

			        } else {

			            $(".iconeEmailInvalido").hide();
			        }
			    });

			});


			$(".txtCpf").mask("999.999.999-99");

	});
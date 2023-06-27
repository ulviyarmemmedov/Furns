 
       let cookieval=Cookies.get("cart");
       if(typeof cookieval!=="undefined" && cookieval!==""){
           cookieval = [...Cookies.get("cart").split("-")];
           $(".shopvalue").text(cookieval.length)

       }

        let prolist=cookieval ?? [];
       
       $(".cart").click(function(){


          let proid=$(this).attr("nese")
          prolist.push(proid);
           Cookies.set("cart", prolist.join("-"))

           $(".shopvalue").text(cookieval.length)


          Swal.fire({
               position: 'center',
               icon: 'success',
               title: 'Your work has been saved',
               showConfirmButton: false,
               timer: 1000
           })
       })



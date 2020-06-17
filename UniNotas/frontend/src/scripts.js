var li_items = document.querySelectorAll (".sidebar ul li");

li_items.forEach((li_items)=>{
    li_item.addEventListener("mouseenter", ()=>{
        console.log(li_item.closest(".wrapper"));
    })
})
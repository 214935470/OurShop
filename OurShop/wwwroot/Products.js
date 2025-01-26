getDataFromUser = () => {
    nameSearch = document.querySelector("#nameSearch").value;
    minPrice = document.querySelector("#minPrice").value;
    maxPrice = document.querySelector("#maxPrice").value;

    return ({nameSearch, minPrice, maxPrice})
}


const filterProducts = async () => {

  
    props = getDataFromUser();
    alert("filterProducts")
    let url = `https://localhost:7057/api/Product/`//just api/Product
    if (props.maxPrice || props.minPrice || props.nameSearch) {
        url + '?'
    }
    if (props.maxPrice) {
        url += `&maxPrice?=${props.maxPrice}`
    }
    if (props.minPrice) {
        url += `&minPrice?=${props.minPrice}`
    }
    if (props.nameSearch) {
        url += `&nameSearch?=${props.nameSearch}`
    }
        const AllProducts = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
                minPrice: props.minPrice,
                maxPrice: props.maxPrice,
                desc: props.nameSearch
            }
        });
    
  

    if (AllProducts.ok) {
        const dataProducts = await AllProducts.json();
        alert(`hello ${dataProducts[0].name}`)
        drawProducts(dataProducts);
    }
    else
        alert("bed request!!")
}

const drawProducts = (dataProducts) => {



}







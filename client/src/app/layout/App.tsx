
import { useEffect, useState } from "react";
import Catalog from "../../features/catalog/catalog";

import { Item } from "../models/item";



export default function App() {
  const [resourceType, setResourceType] = useState(1)
  const [Item, setItems] = useState([])
  useEffect(() => {
    fetch(`http://localhost:5000/Get_Item_Details/${resourceType}`)
      .then(response => response.json())
      .then(json => setItems(json))
  }, [resourceType])
  return (
    <>
      <div>
        <Catalog />
        <button onClick={() => setResourceType(1)}>Posts</button>
      </div>
      <h1>{resourceType}</h1>
      {Item.map(item => {
        return <pre>{JSON.stringify(item)}</pre>
      })}
    </>
  );
}



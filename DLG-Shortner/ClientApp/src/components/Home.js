import React, { useEffect, useState } from 'react';
import { NotificationManager } from 'react-notifications';

export const Home = () => {

  const [url, setUrl] = useState("")
  const [slug, setSlug] = useState("")

  useEffect(() => {
    fetch("/")
  }, [])

  const onSubmit = async () => {
    if (!url) {
      NotificationManager.console.warn('Url is empty', 'Warning');
      return;
    }

    var res = await fetch("/url/", { method: "POST", body: { url, slug } })

    console.log(res)
  }


  return (
    <div>
      <form onSubmit={onSubmit}>
        <label htmlFor="url">Url</label>
        <input id="url" onChange={(e) => setUrl(e.target.value)} placeholder='https://example.com' />

        <label htmlFor="slug">Slug</label>
        <input id="slug" onChange={(e) => setSlug(e.target.value)} placeholder='slugy' />
        <button type="submit"> Ok</button>
      </form>
    </div>
  )

}

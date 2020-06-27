import React, { useEffect, useState } from 'react';
import urlApi from "../api/urlApi"
import { Helmet } from "react-helmet";
import { useForm } from "react-hook-form";
import { NotificationManager } from 'react-notifications';

export const Home = () => {
    const { register, errors, handleSubmit } = useForm();
    const urlRegex = /(((http|ftp|https):\/{2})+(([0-9a-z_-]+\.)+(aero|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|ax|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cu|cv|cx|cy|cz|cz|de|dj|dk|dm|do|dz|ec|ee|eg|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|me|mg|mh|mk|ml|mn|mn|mo|mp|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|nom|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ra|rs|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|sj|sk|sl|sm|sn|so|sr|st|su|sv|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw|arpa)(:[0-9]+)?((\/([~0-9a-zA-Z\#\+\%@\.\/_-]+))?(\?[0-9a-zA-Z\+\%@\/&\[\];=_-]+)?)?))\b/imu;
    const [result, setResult] = useState("")
    const [loading, setLoading] = useState(null)



    useEffect(() => {
        fetch("/")
    }, [])

    const onSubmit = async (data) => {
        setLoading(true)
        data.url = data.url.replace(/^https:\/\//i, 'http://')
        var res = await urlApi.post("", data)
        const newUrl = `https://dlg-shortner.herokuapp.com/u/${res.data.slug}`;
        setResult(newUrl);
        navigator.clipboard.writeText(newUrl)
        NotificationManager.success("Copied to clipboard", "Woohoo!")
        setLoading(false)
    }


    return (
        <div>
            <Helmet>
                <title>Short Urls!</title>
            </Helmet>
            <div>
                Short Url for your personal use!
            </div>
            <form onSubmit={handleSubmit(onSubmit)}>
                <div>
                    <div>Url</div>
                    <input autocomplete="off" name="url" ref={register({ required: true, pattern: urlRegex })} />
                    <div>
                        {errors.url && errors.url.type === "required" && "url is required"}
                        {errors.url && errors.url.type === "pattern" && "thats not a url"}
                    </div>
                </div>
                <div>
                    <div>Slug</div>
                    <input autocomplete="off" name="slug" ref={register({ pattern: /^[a-z0-9]{0,5}$/i })} />
                    <div>
                        {errors.slug && "slug must be maximum 5 lowercase characters or numbers"}
                    </div>
                    <input type="submit" />
                </div>
            </form>
            {loading && <div>Loading</div>}
            {result && <div class="result">
                Here you go: <span class="result-link">{result}</span>
            </div>}
        </div >
    )

}

import Image from 'next/image'
import RegisterForm from '../../components/Form/RegisterForm'

const register = () => {
  return (
    <div class="w-screen h-screen bg-white flex">
      <div class="m-auto w-1/4 text-center"><Image src="/Gs-logo.png" width="450px" height="450px" layout="responsive" /></div>
      <div class="w-1 h-4/6 bg-black my-auto"></div>
      <div class="container m-auto h-5/6 w-2/5 p-8 bg-sky-700 rounded-lg" style={{overflow: 'scroll', backgroundColor: '#6388BD'}}>
        <RegisterForm  />
      </div>
    </div>
  )
}

export default register
